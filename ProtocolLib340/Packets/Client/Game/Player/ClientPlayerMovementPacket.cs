using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientPlayerMovementPacket : IPacket
    {
        public bool OnGround { get; set; }        
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteBoolean(OnGround);
        }

        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public ClientPlayerMovementPacket()
        {

        }
        public ClientPlayerMovementPacket(bool onGround)
        {
            OnGround = onGround;
        }
    }
}
