using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketInfo(0x43, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntitySetPassengersPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.passengerIds = new int[in.readVarInt()];
       //for(int index = 0; index < this.passengerIds.length; index++) {
       //this.passengerIds[index] = in.readVarInt();
       //}
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntitySetPassengersPacket() {}
    }

}
