﻿using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Server
{

    public class LoginSuccessPacket : IPacket
    {
        public Guid UUID { get; set; }
        public string Username { get; set; }
        public void Read(IMinecraftStreamReader stream)
        {
            UUID = stream.ReadGuid();
            Username = stream.ReadString();
        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }

        public LoginSuccessPacket(Guid uUID, string username)
        {
            UUID = uUID;
            Username = username;
        }

        public LoginSuccessPacket() { }
    }
}
