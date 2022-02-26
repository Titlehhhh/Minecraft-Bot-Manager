﻿using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib740.Packets.Server.Login
{
    
    public class LoginPluginRequestPacket : IPacket
    {
        public int MessageID { get; set; }
        public string Channel { get; set; }
        public byte[] Data { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            int len =(int) stream.Length;
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
