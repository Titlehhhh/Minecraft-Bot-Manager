using MinecraftLibrary.Data;
using MinecraftLibrary.MinecraftProtocol.Data;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;


namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientPlayerActionPacket : ClientPacket
    {
        public PlayerAction Action { get; set; }
        public Location Position { get; set; }
        public Direction Face { get; set; }
        public void Write(NetOutput output, int version)
        {
            output.WriteVarInt((int)Action);
            output.WriteLocation(Position);
            output.WriteVarInt((int)Face);
            
        }

        public ClientPlayerActionPacket(PlayerAction action, Location position, Direction face)
        {
            Action = action;
            Position = position;
            Face = face;
        }
    }



}
