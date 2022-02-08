using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketMeta(0x37, 340, PacketSide.Server, PacketCategory.Game)]
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
