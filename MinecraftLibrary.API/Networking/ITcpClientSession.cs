﻿using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;

namespace MinecraftLibrary.API.Networking
{
    public interface ITcpClientSession
    {
        int CompressionThreshold { set; }
        string Host { get; set; }        
        int Port { get; set; }
        ProxyInfo? Proxy { get; set; }

        IPacketRepository InputPackets { get; set; }

        event Action<ITcpClientSession>? Connected;
        event EventHandler<DisconnectedEventArgs>? Disconnected;
        event EventHandler<PacketReceivedEventArgs>? PacketReceived;
        event EventHandler<PacketSendEventArgs>? PacketSend;
        event EventHandler<PacketSentEventArgs>? PacketSent;

        void Connect();
        void Disconnect();
        void Dispose();
        void SendPacket(IPacket packet, int id);
        void SwitchEncryption(byte[] key);
    }
}
