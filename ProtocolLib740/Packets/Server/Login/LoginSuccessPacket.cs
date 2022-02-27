using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib740.Packets.Server
{
    
    public class LoginSuccessPacket : IPacket
    {
        public string UUID { get; set; }
        public string Username { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            UUID = stream.ReadString();
            Username = stream.ReadString();
        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public LoginSuccessPacket()
        {

        }
    }
}
