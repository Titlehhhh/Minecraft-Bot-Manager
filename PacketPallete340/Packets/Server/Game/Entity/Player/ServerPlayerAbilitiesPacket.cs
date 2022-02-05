using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity.Player
{

    [PacketMeta(0x2C, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerAbilitiesPacket : MinecraftPacket
    {
        //byte flags = in.readByte();
       //this.invincible = (flags & 1) > 0;
       //this.canFly = (flags & 2) > 0;
       //this.flying = (flags & 4) > 0;
       //this.creative = (flags & 8) > 0;
       //this.flySpeed = in.readFloat();
       //this.walkSpeed = in.readFloat();
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerPlayerAbilitiesPacket() {}
    }

}