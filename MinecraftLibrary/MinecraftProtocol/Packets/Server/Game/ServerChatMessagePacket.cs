using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerChatMessagePacket : ServerPacket
    {
        public string Message;
        public MessageType type;
        public void Read(NetInput input, int version)
        {
            Message = input.ReadNextString();
            type = (MessageType)input.ReadNextByte();
        }

    }
    public enum MessageType : byte
    {
        CHAT,
        SYSTEM,
        NOTIFICATION
    }


}
