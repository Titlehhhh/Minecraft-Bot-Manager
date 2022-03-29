using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using System.Net.Sockets;

namespace MinecraftLibrary.API.Networking
{

    public sealed class TcpClientSession : IDisposable
    {
        public bool IsConnected => tcpClient != null && tcpClient.Connected;

        public NetworkMinecraftStream NetStream { get; private set; }
        public IPacketReaderWriter PacketReaderWriter { get; private set; }
        public IPacketProducer PacketFactory { get; set; }


        public string Host { get; init; }
        public int Port { get; init; }

        public bool ProxyEnabled { get; set; }
        public ProxyInfo? Proxy { get; set; }


        public CancellationTokenSource Cancellation { get; private set; } = new();

        public int CompressionThreshold { set => PacketReaderWriter.CompressionThreshold = value; }

        public void SwitchEncryption(byte[] key)
        {
            NetStream.SwitchEncryption(key);
        }


        public event Action? Connected;
        public event EventHandler? Disconnecting;
        public event EventHandler<Exception>? Disconnected;
        public event EventHandler<PacketReceivedEventArgs>? PacketReceived;
        public event EventHandler<PacketSendEventArgs>? PacketSend;
        public event EventHandler<PacketSentEventArgs>? PacketSent;

        private TcpClient tcpClient;

        public async Task Connect()
        {
            await Task.Run(async () =>
            {
                tcpClient = new TcpClient(Host, Port);
                tcpClient.ReceiveBufferSize = 1024 * 1024;
                tcpClient.ReceiveTimeout = 30000;
                NetStream = new NetworkMinecraftStream(tcpClient.GetStream());
                this.PacketReaderWriter = new PacketReaderWriter(NetStream);

                Connected?.Invoke();
                ReadLoop();
            });
        }
        private void ReadLoop()
        {
            new Thread(async () =>
            {
                try
                {
                    while (tcpClient.Connected && !Cancellation.IsCancellationRequested)
                    {
                        (int id, MinecraftStream dataStream) = await PacketReaderWriter.ReadNextPacketAsync();
                        Lazy<IPacket> packet = null;
                        if (PacketFactory.TryGetInputPacket(id, out packet))
                        {
                            packet.Value.Read(dataStream);
                            PacketReceived?.Invoke(this, new PacketReceivedEventArgs(id, packet.Value));
                        }
                    }
                }
                catch (Exception e)
                {
                    Disconnected?.Invoke(this, e);
                }
                finally
                {
                    Console.WriteLine("Close");
                    tcpClient.Close();
                    Dispose();
                }
            }).Start();
        }


        public void Disconnect()
        {
            Disconnecting?.Invoke(this, null);
            Cancellation.Cancel();
        }
        public async void SendPacket(IPacket packet, int id)
        {
            try
            {

                ArgumentNullException.ThrowIfNull(packet, nameof(packet));
                PacketSend?.Invoke(this, new PacketSendEventArgs(packet));
                await PacketReaderWriter.WritePacketAsync(packet, id);
                PacketSent?.Invoke(this, new PacketSentEventArgs(packet));

                Console.WriteLine("Пакет отправлен: " + packet.GetType().Name);
            }
            catch (Exception e)
            {
                Disconnect();
                this.Disconnected?.Invoke(this, e);
            }
        }


        public void Dispose()
        {
            Cancellation.Dispose();
            tcpClient?.Dispose();
            PacketReaderWriter?.Dispose();


            Connected = null;
            Disconnected = null;

            tcpClient = null;
            PacketReaderWriter = null;
            Cancellation = null;

            GC.SuppressFinalize(this);
        }

        public void SendPacket(IPacket packet)
        {
            if (PacketFactory.TryGetOutputId(packet.GetType(), out int id))
            {
                this.SendPacket(packet, id);
            }
        }

        ~TcpClientSession()
        {
            Dispose();
        }
    }
}
