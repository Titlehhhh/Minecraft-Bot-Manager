using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketHeader(0x0C, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerMovementPacket : IPacket
    {
        public bool OnGround { get; set; }        
        public void Write(MinecraftStream stream)
        {
            stream.WriteBoolean(OnGround);
        }

        public void Read(MinecraftStream stream)
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
