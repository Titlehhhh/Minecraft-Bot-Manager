using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.API.Protocol.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Protocol.Packets.Client.Game
{
    [PacketMetaGame(0x03)]
    public class ClientChatPacket : ClientPacket
    {
        public ClientChatPacket(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteString(Message);
        }
    }
}
