using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerPluginMessagePacket : ServerPacket
    {
        public string Channel { get; private set; }
        public void Read(NetInput input, int version)
        {
            Channel = input.ReadNextString();

        }
    }


}
