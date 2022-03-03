﻿using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib740.Packets.Server
{

    public class LoginSetCompressionPacket : IPacket
    {
        public int Threshold { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            Threshold = stream.ReadVarInt();
        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public LoginSetCompressionPacket()
        {

        }
    }
}
