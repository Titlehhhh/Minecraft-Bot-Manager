using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketHeader(0x15, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerWindowPropertyPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.property = in.readShort();
       //this.value = in.readShort();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerWindowPropertyPacket() {}
    }

}
