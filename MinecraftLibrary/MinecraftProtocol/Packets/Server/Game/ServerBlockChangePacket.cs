﻿using MinecraftLibrary.Data;
using MinecraftLibrary.MinecraftProtocol.Data.Inventory;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerBlockChangePacket : ServerPacket
    {
        public Point3D_I32 Position { get; private set; }
        public ushort ID { get; set; }
        public Block Block { get; private set; }
        public void Read(NetInput input, int version)
        {
            Position = input.ReadNextLocation();
            ID = (ushort)input.ReadNextVarInt();
            Block = new Block(ID, Position);
        }
    }


}