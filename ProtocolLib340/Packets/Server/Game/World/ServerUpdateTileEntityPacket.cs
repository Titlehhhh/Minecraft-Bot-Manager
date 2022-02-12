using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketHeader(0x09, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUpdateTileEntityPacket : IPacket
    {
        //this.position = NetUtil.readPosition(in);
       //this.type = MagicValues.key(UpdatedTileType.class, in.readUnsignedByte());
       //this.nbt = NetUtil.readNBT(in);
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerUpdateTileEntityPacket() {}
    }

}
