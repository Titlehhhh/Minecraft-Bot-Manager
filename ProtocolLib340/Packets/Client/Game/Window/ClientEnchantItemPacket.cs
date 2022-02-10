using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketInfo(0x06, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientEnchantItemPacket : MinecraftPacket
    {
        //out.writeByte(this.windowId);
       //out.writeByte(this.enchantment);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
