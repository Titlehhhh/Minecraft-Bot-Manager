using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib740.Packets.Server.Login
{
    [PacketHeader(0x00,740,PacketSide.Server,PacketCategory.Game)]
    public class LoginDisconnectPacket : IPacket
    {
        public string Message { get; set; }

        public void Read(MinecraftStream stream)
        {
            Message = stream.ReadString();
        }

        public void Write(MinecraftStream stream)
        {
            stream.WriteString(Message);
        }
        public LoginDisconnectPacket()
        {

        }
    }
}
