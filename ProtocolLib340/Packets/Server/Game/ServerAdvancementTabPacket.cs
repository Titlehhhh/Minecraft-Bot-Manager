using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x37, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerAdvancementTabPacket : MinecraftPacket
    {
        //if(in.readBoolean()) {
       //this.tabId = in.readString();
       //} else {
       //this.tabId = null;
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerAdvancementTabPacket() {}
    }

}
