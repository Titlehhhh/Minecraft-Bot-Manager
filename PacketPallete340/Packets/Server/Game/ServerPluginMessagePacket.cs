using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game
{

    [PacketMeta(0x18, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerPluginMessagePacket : MinecraftPacket
    {
        //this.channel = in.readString();
       //this.data = in.readBytes(in.available());
        public override void Read(MinecraftStream output)
        {
            
        }
        public ServerPluginMessagePacket() {}
    }

}
