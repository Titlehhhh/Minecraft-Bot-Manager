using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Entity.Player
{

    
    public class ServerPlayerPositionRotationPacket : IPacket
    {
        //this.x = in.readDouble();
        //this.y = in.readDouble();
        //this.z = in.readDouble();
        //this.yaw = in.readFloat();
        //this.pitch = in.readFloat();
        //this.relative = new ArrayList<PositionElement>();
        //int flags = in.readUnsignedByte();
        //for(PositionElement element : PositionElement.values()) {
        //int bit = 1 << MagicValues.value(Integer.class, element);
        //if((flags & bit) == bit) {
        //this.relative.add(element);
        //}
        //}
        //
        //this.teleportId = in.readVarInt();
        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerPlayerPositionRotationPacket() { }
    }

}
