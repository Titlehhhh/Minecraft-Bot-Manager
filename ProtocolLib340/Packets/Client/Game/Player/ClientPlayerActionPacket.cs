using MinecraftLibrary.API;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.Geometry;

using static ProtocolLib340.Constans;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketMeta(0x14, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerActionPacket : MinecraftPacket
    {
        public PlayerAction Action { get; set; }
        public Point3_Int Position { get; set; }
        public BlockFace Face { get; set; }
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteVarInt((int)Action);
            long x = Position.X & POSITION_WRITE_SHIFT;
            long y = Position.Y & POSITION_X_SIZE;
            long z = Position.Z & POSITION_WRITE_SHIFT;

            output.WriteLong(x << POSITION_X_SIZE | y << POSITION_Y_SIZE | z);

            output.WriteByte((byte)Face);
        }

        public ClientPlayerActionPacket(PlayerAction action, Point3_Int position, BlockFace face)
        {
            Action = action;
            Position = position;
            Face = face;
        }
    }
}
