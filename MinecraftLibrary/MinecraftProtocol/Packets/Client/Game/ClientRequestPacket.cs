using MinecraftLibrary.MinecraftProtocol.Data;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientRequestPacket : ClientPacket
    {
        public ClientRequest ClientRequest { get; set; }
        public ClientRequestPacket()
        {

        }
        public ClientRequestPacket(ClientRequest clientRequest)
        {
            ClientRequest = clientRequest;
        }
        public void Write(NetOutput output, int protocolversion)
        {
            output.WriteVarInt((int)ClientRequest);
        }
    }
}
