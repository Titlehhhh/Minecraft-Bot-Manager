using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Login
{
    public class LoginSuccesPacket : ServerPacket
    {
        public Guid UUID;
        public string NickName;
        public void Read(NetInput input, int version)
        {
            UUID = input.ReadNextUUID();
            NickName = input.ReadNextString();
        }

    }
}
