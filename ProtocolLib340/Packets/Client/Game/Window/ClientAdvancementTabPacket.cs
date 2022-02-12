using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketHeader(0x19, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientAdvancementTabPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
