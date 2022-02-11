using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x4A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPlayerListDataPacket : IPacket
    {
        //this.header = Message.fromString(in.readString());
       //this.footer = Message.fromString(in.readString());
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerPlayerListDataPacket() {}
    }

}
