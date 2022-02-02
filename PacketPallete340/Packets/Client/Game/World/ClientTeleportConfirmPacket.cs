using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.World
{
    //out.writeVarInt(this.id);
    [PacketMeta(0x00, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientTeleportConfirmPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
