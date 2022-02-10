using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x09, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUpdateTileEntityPacket : MinecraftPacket
    {
        //this.position = NetUtil.readPosition(in);
       //this.type = MagicValues.key(UpdatedTileType.class, in.readUnsignedByte());
       //this.nbt = NetUtil.readNBT(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerUpdateTileEntityPacket() {}
    }

}
