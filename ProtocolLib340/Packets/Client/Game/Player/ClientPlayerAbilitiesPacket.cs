using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x13, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerAbilitiesPacket : MinecraftPacket
    {
        //byte flags = 0;
       //if(this.invincible) {
       //flags = (byte) (flags | 1);
       //}
       //
       //if(this.canFly) {
       //flags = (byte) (flags | 2);
       //}
       //
       //if(this.flying) {
       //flags = (byte) (flags | 4);
       //}
       //
       //if(this.creative) {
       //flags = (byte) (flags | 8);
       //}
       //
       //out.writeByte(flags);
       //out.writeFloat(this.flySpeed);
       //out.writeFloat(this.walkSpeed);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
