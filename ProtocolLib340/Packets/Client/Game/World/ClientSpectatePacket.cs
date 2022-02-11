using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketInfo(0x1E, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSpectatePacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeUUID(this.target);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
