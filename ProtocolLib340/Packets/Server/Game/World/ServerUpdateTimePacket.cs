using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x47, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerUpdateTimePacket : IPacket
    {
        //this.age = in.readLong();
       //this.time = in.readLong();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerUpdateTimePacket() {}
    }

}
