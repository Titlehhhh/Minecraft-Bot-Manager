﻿using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerSpawnPaintingPacket : ServerPacket
    {
        public int ID { get; private set; }
        public void Read(NetInput input, int version)
        {
            ID = input.ReadNextVarInt();
        }
    }


}