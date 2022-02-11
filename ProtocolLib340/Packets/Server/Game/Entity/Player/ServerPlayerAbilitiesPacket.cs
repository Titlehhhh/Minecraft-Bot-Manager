using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    [PacketInfo(0x2C, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerAbilitiesPacket : IPacket
    {
        //byte flags = in.readByte();
       //this.invincible = (flags & 1) > 0;
       //this.canFly = (flags & 2) > 0;
       //this.flying = (flags & 4) > 0;
       //this.creative = (flags & 8) > 0;
       //this.flySpeed = in.readFloat();
       //this.walkSpeed = in.readFloat();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayerAbilitiesPacket() {}
    }

}
