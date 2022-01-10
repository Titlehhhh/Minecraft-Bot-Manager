using MinecraftLibrary.Data;
using MinecraftLibrary.Geometri;
using MinecraftLibrary.MinecraftProtocol.Data;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;


namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientPlayerActionPacket : ClientPacket
    {
        public PlayerAction Action { get; set; }
        public Point3 Position { get; set; }
        public Direction Face { get; set; }
        public void Write(NetOutput output, int version)
        {
            output.WriteVarInt((int)Action);
            output.WriteLocation(Position);
            output.WriteVarInt((int)Face);
            
        }

        public ClientPlayerActionPacket(PlayerAction action, Point3 position, Direction face)
        {
            Action = action;
            Position = position;
            Face = face;
        }
    }



}
