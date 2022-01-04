using MinecraftLibrary.Data;
using MinecraftLibrary.Palletes;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Game
{
    
    public class ServerSpawnEntityPacket : ServerPacket
    {
        public Entity NewEntity { get; private set; }
        public void Read(NetInput input, int version)
        {
            NewEntity = input.ReadNextEntity(PalletesExtensions.GetEntityPalette(version), false);

        }
    }


}
