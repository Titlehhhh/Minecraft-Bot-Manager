using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using System.Net.Sockets;
using System.Threading.Tasks.Dataflow;
using System.IO;

namespace MinecraftLibrary.API.Networking
{

    

    public sealed class TcpClientSession : IDisposable
    {
        public static void Debug(string msg)
        {
            using (StreamWriter sw = new StreamWriter(@"C:\Users\Title\Desktop\debug.txt", true))
            {
                sw.WriteLine(msg);
            }
        }

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

        private Task readTask;

        public async Task Connect()
        {

            Cancellation = new CancellationTokenSource();

            var blockOptions = new ExecutionDataflowBlockOptions { CancellationToken = Cancellation.Token, EnsureOrdered = true };




            tcpClient = new TcpClient(Host, Port);
            tcpClient.ReceiveBufferSize = 1024 * 1024;
            tcpClient.ReceiveTimeout = 30000;
            NetStream = new NetworkMinecraftStream(tcpClient.GetStream());
            this.PacketReaderWriter = new PacketReaderWriter(NetStream);

            Connected?.Invoke();
            readTask = ReadLoop();
        }
        private Task ReadLoop()
        {
            return Task.Run(async () =>
              {
                  try
                  {
                      while (tcpClient.Connected && !Cancellation.IsCancellationRequested)
                      {
                          (int id, MinecraftStream dataStream) = await PacketReaderWriter.ReadNextPacketAsync(Cancellation.Token);
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
                      //Dispose();
                  }
              });

        }
        private bool IsDisconnect = false;

        public async Task DisconnectAsync()
        {
            IsDisconnect = true;
            Cancellation.Cancel();
            try
            {
                await Task.WhenAll(readTask).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {

            }
            finally
            {

            }

        }
        private async Task SendPacketAsync(IPacket packet, int id)
        {
            Cancellation.Token.ThrowIfCancellationRequested();
            try
            {
                Debug("Пакет отправляется: "+id+" : " + packet.GetType().Name);
                ArgumentNullException.ThrowIfNull(packet, nameof(packet));
                PacketSend?.Invoke(this, new PacketSendEventArgs(packet));
                await PacketReaderWriter.WritePacketAsync(packet, id,Cancellation.Token);
                Debug("Пакет отправлен: " + packet.GetType().Name);
                PacketSent?.Invoke(this, new PacketSentEventArgs(packet));

               
            }
            catch (IOException e)
            {
                if (!IsDisconnect)
                {
                    Cancellation.Cancel();

                   await Task.WhenAll(readTask);

                    this.Disconnected?.Invoke(this, e);
                }
            }
            catch (Exception e)
            {
                if (!IsDisconnect)
                {
                    Cancellation.Cancel();

                    await Task.WhenAll(readTask);

                    this.Disconnected?.Invoke(this, e);
                }
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

        public async Task QueuePacketAsync(IPacket packet)
        {
            //Debug("QUEUE Пакет: " + packet.GetType().Name);
            await Task.Run(async () =>
              {
                  await SendPacketAsync(packet);
              });
        }

        private async Task SendPacketAsync(IPacket packet)
        {
            //Debug("Sendpac: " + packet.GetType().Name);
            if (PacketFactory.TryGetOutputId(packet.GetType(), out int id))
            {
                await this.SendPacketAsync(packet, id);
            }
        }

        ~TcpClientSession()
        {
            Dispose();
        }
    }
}
