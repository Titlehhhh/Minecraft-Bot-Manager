using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketHeader(0x06, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientEnchantItemPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeByte(this.windowId);
        //out.writeByte(this.enchantment);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
