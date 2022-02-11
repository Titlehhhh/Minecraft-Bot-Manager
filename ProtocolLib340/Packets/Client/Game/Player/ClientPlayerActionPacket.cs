using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using MinecraftLibrary.Geometry;

using static ProtocolLib340.Constans;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x14, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerActionPacket : IPacket
    {
        public PlayerAction Action { get; set; }
        public Point3_Int Position { get; set; }
        public BlockFace Face { get; set; }
        public void Write(MinecraftStream stream)
        {
            stream.WriteVarInt((int)Action);
            long x = Position.X & POSITION_WRITE_SHIFT;
            long y = Position.Y & POSITION_X_SIZE;
            long z = Position.Z & POSITION_WRITE_SHIFT;

            stream.WriteLong(x << POSITION_X_SIZE | y << POSITION_Y_SIZE | z);

            stream.WriteByte((byte)Face);
        }

        public void Read(MinecraftStream stream)
        {
            
        }

        public ClientPlayerActionPacket(PlayerAction action, Point3_Int position, BlockFace face)
        {
            Action = action;
            Position = position;
            Face = face;
        }
    }
}
