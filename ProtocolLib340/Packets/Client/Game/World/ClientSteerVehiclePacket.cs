using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketMeta(0x16, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSteerVehiclePacket : MinecraftPacket
    {
        //out.writeFloat(this.sideways);
       //out.writeFloat(this.forward);
       //byte flags = 0;
       //if(this.jump) {
       //flags = (byte) (flags | 1);
       //}
       //
       //if(this.dismount) {
       //flags = (byte) (flags | 2);
       //}
       //
       //out.writeByte(flags);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
