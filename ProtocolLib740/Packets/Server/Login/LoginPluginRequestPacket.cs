﻿using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib754.Packets.Server
{
    [PacketInfo(0x04, 740, PacketCategory.Login, PacketSide.Server)]
    public class LoginPluginRequestPacket : IPacket
    {
        public int MessageID { get; set; }
        public string Channel { get; set; }
        public byte[] Data { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            int len = (int)stream.Length;
            MessageID = stream.ReadVarInt();
            Channel = stream.ReadString();
            Data = stream.ReadUInt8Array(len - ((int)stream.Length));
        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }

        public LoginPluginRequestPacket()
        {

        }
    }
}
