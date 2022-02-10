using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x18, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPluginMessagePacket : MinecraftPacket
    {
        //this.channel = in.readString();
       //this.data = in.readBytes(in.available());
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerPluginMessagePacket() {}
    }

}
