using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.Entity.Player
{

    [PacketMeta(0x2F, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerPositionRotationPacket : MinecraftPacket
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
        public override void Read(MinecraftStream output)
        {

        }
        public ServerPlayerPositionRotationPacket() { }
    }

}
