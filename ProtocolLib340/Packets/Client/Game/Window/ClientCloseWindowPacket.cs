using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Window
{

    [PacketInfo(0x08, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientCloseWindowPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeByte(this.windowId);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
