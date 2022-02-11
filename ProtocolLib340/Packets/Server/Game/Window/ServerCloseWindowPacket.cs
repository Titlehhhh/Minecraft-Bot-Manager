using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Window
{

    [PacketInfo(0x12, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerCloseWindowPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerCloseWindowPacket() {}
    }

}
