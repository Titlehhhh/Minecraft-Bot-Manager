using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketHeader(0x18, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientResourcePackStatusPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeVarInt(MagicValues.value(Integer.class, this.status));
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
