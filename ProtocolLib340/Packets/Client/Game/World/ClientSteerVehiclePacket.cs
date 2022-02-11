using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketInfo(0x16, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSteerVehiclePacket : IPacket
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
