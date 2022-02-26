using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.World
{

    
    public class ServerUpdateTileEntityPacket : IPacket
    {
        //this.position = NetUtil.readPosition(in);
       //this.type = MagicValues.key(UpdatedTileType.class, in.readUnsignedByte());
       //this.nbt = NetUtil.readNBT(in);
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerUpdateTileEntityPacket() {}
    }

}
