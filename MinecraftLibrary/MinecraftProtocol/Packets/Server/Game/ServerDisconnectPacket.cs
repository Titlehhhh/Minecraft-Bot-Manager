using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    public class ServerDisconnectPacket : ServerPacket
    {
        public string DisconnectMessage { get; private set; }
        public void Read(NetInput input, int version)
        {
            DisconnectMessage = input.ReadNextString();
        }
    }


}
