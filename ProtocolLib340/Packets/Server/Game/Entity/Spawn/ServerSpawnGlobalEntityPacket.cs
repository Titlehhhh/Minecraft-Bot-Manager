using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Server
{


    public class ServerSpawnGlobalEntityPacket : IPacket
    {
        //this.entityId = in.readVarInt();
        //this.type = MagicValues.key(GlobalEntityType.class, in.readByte());
        //this.x = in.readDouble();
        //this.y = in.readDouble();
        //this.z = in.readDouble();
        public void Read(IMinecraftStreamReader stream)
        {

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }

        public ServerSpawnGlobalEntityPacket() { }
    }

}
