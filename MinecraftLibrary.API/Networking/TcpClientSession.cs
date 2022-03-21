﻿using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
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


        public string Host { get; set; }
        public int Port { get; set; }
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

        public void Connect()
        {
            tcpClient = new TcpClient(Host, Port);


            NetStream = new NetworkMinecraftStream(tcpClient.GetStream());
            this.PacketReaderWriter = new PacketReaderWriter(NetStream);

            Connected?.Invoke();
            ReadLoop();
        }
        private async void ReadLoop()
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
                tcpClient.Close();
                Dispose();
            }
        }


        public void Disconnect()
        {
            Disconnecting?.Invoke(this, null);
            Cancellation.Cancel();
        }
        public void SendPacket(IPacket packet, int id)
        {
            ArgumentNullException.ThrowIfNull(packet, nameof(packet));
            PacketSend?.Invoke(this, new PacketSendEventArgs(packet));

            PacketSent?.Invoke(this, new PacketSentEventArgs(packet));

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
