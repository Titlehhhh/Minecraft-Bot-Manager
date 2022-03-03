using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib740.Packets.Server
{
    [PacketInfo(0x00, 740, PacketCategory.Login, PacketSide.Server)]
    public class LoginDisconnectPacket : IPacket
    {
        public string Message { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            Message = stream.ReadString();
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteString(Message);
        }
        public LoginDisconnectPacket()
        {

        }
    }
}
