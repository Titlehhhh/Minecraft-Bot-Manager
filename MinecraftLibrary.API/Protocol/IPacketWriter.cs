﻿using MinecraftLibrary.API.Protocol.Events;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketWriter
    {
        void SendPacket(IPacket packet);
        void SendPacket(IPacket packet, int id);
        event EventHandler<PacketSendEventArgs> PacketSendEvent;
        event EventHandler<PacketSentEventArgs> PacketSentEvent;
        void RegisterPacketOutput(int id, Type t);
        bool UnRegisterPacketOutput(Type t);

    }

}