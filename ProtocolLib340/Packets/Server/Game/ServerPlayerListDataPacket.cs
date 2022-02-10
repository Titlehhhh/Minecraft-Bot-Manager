using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x4A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerListDataPacket : MinecraftPacket
    {
        //this.header = Message.fromString(in.readString());
       //this.footer = Message.fromString(in.readString());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPlayerListDataPacket() {}
    }

}
