using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib740.Packets.Server
{
   
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
