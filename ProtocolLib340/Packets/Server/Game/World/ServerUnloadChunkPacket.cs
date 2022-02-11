using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x1D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUnloadChunkPacket : IPacket
    {
        //this.x = in.readInt();
       //this.z = in.readInt();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerUnloadChunkPacket() {}
    }

}
