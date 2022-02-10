using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketInfo(0x04, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnPaintingPacket : MinecraftPacket
    {
        //this.entityId = in.readVarInt();
       //this.uuid = in.readUUID();
       //this.paintingType = MagicValues.key(PaintingType.class, in.readString());
       //this.position = NetUtil.readPosition(in);
       //this.direction = MagicValues.key(HangingDirection.class, in.readUnsignedByte());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSpawnPaintingPacket() {}
    }

}
