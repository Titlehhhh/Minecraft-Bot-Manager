using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib740.Packets.Client.Login
{
    
    public class LoginStartPacket : IPacket
    {
        public string Nickname { get; set; }
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteString(Nickname);
        }

        public void Read(IMinecraftStreamReader stream)
        {

        }

        public LoginStartPacket(string nickname)
        {
            Nickname = nickname;
        }
        public LoginStartPacket()
        {

        }
    }
}
