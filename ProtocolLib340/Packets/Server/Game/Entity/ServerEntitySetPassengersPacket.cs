using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x43, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntitySetPassengersPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.passengerIds = new int[in.readVarInt()];
       //for(int index = 0; index < this.passengerIds.length; index++) {
       //this.passengerIds[index] = in.readVarInt();
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerEntitySetPassengersPacket() {}
    }

}
