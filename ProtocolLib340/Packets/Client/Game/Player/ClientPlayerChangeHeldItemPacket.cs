using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketHeader(0x1A, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerChangeHeldItemPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeShort(this.slot);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
