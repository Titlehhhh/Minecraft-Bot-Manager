using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Login
{
    public class ServerPluginRequestPacket : ServerPacket
    {
        public int MessageID { get; private set; }
        public string Channel { get; private set; }
        public void Read(NetInput input, int protocovesrion)
        {
            MessageID = input.ReadNextVarInt();
            Channel = input.ReadNextString();
        }
    }
}
