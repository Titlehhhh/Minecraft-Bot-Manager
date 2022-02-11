using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketInfo(0x1B, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientCreativeInventoryActionPacket : IPacket
    {
        //out.writeShort(this.slot);
        //NetUtil.writeItem(out, this.clicked);
        public override void Write(IMinecraftStreamWriter output)
        {

        }
    }
}
