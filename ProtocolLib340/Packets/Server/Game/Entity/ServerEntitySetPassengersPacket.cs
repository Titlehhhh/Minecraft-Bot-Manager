using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity
{

    
    public class ServerEntitySetPassengersPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.passengerIds = new int[in.readVarInt()];
       //for(int index = 0; index < this.passengerIds.length; index++) {
       //this.passengerIds[index] = in.readVarInt();
       //}
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerEntitySetPassengersPacket() {}
    }

}
