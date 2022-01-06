using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerPlayerHealthPacket : ServerPacket
    {
        public float Health { get; private set; }
        public int Food { get; private set; }
        public float Saturation { get; private set; }
        public void Read(NetInput input, int version)
        {
            Health = input.ReadNextFloat();
            Food = input.ReadNextVarInt();
            Saturation = input.ReadNextFloat();
        }
    }
}
