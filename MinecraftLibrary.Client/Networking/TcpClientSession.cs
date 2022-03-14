using Ionic.Zlib;
using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using System.Net.Sockets;

namespace MinecraftLibrary.Client.Networking
{

    public sealed class TcpClientSession : IDisposable, ITcpClientSession
    {
        public NetworkMinecraftStream NetStream { get; private set; }


        public string Host { get; set; }
        public int Port { get; set; }
        public ProxyInfo? Proxy { get; set; }


        public CancellationTokenSource Cancellation { get; private set; } = new();
        public int CompressionThreshold { get; set; } = 0;

        public IPacketProducer PacketFactory { get; set; }

        public event Action<ITcpClientSession>? Connected;
        public event EventHandler<DisconnectedEventArgs>? Disconnected;
        public event EventHandler<PacketReceivedEventArgs>? PacketReceived;
        public event EventHandler<PacketSendEventArgs>? PacketSend;
        public event EventHandler<PacketSentEventArgs>? PacketSent;

        private TcpClient tcpClient;

        public void Connect()
        {
            tcpClient = new TcpClient(Host, Port);


            NetStream = new NetworkMinecraftStream(tcpClient.GetStream());


            Connected?.Invoke(this);
            ReadLoop();
        }
        private async void ReadLoop()
        {
            try
            {
                while (tcpClient.Connected && !Cancellation.IsCancellationRequested)
                {
                    (int id, MinecraftStream dataStream) = await ReadNextPacketAsync();
                    Lazy<IPacket> packet = null;
                    if (PacketFactory.TryGetInputPacket(id, out packet))
                    {
                        packet.Value.Read(dataStream);
                        PacketReceived?.Invoke(this, new PacketReceivedEventArgs(id, packet.Value));
                    }
                }
            }
            catch (SocketException e)
            {
                Disconnected?.Invoke(this, new DisconnectedEventArgs("Ошибка при чтении", e));
            }
            catch (Exception e)
            {

            }
            finally
            {
                Cancellation.Cancel();
            }
        }


        public void Disconnect()
        {
            Cancellation.Cancel();
        }
        public void SendPacket(IPacket packet, int id)
        {
            ArgumentNullException.ThrowIfNull(packet, nameof(packet));
            PacketSend?.Invoke(this, new PacketSendEventArgs(packet));

            PacketSent?.Invoke(this, new PacketSentEventArgs(packet));

        }



        public void SwitchEncryption(byte[] key)
        {
            NetStream.SwitchEncryption(key);
        }
        public void Dispose()
        {
            Cancellation.Dispose();
            tcpClient?.Dispose();
            NetStream?.Dispose();

            Connected = null;
            Disconnected = null;

            tcpClient = null;
            NetStream = null;
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
