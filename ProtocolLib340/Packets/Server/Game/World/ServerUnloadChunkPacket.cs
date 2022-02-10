using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x1D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUnloadChunkPacket : MinecraftPacket
    {
        //this.x = in.readInt();
       //this.z = in.readInt();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerUnloadChunkPacket() {}
    }

}
