using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerKeepAlivePacket : ServerPacket
    {
        public long PingId;
        public void Read(NetInput input, int version)
        {
            PingId = input.ReadNextLong();
        }

    }
}
