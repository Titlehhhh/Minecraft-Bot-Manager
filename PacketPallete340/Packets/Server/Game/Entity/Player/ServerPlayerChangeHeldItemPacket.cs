using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity.Player
{

    [PacketMeta(0x3A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerChangeHeldItemPacket : MinecraftPacket
    {
        //this.slot = in.readByte();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayerChangeHeldItemPacket() {}
    }

}
