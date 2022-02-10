using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x09, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPluginMessagePacket : MinecraftPacket
    {
        //out.writeString(this.channel);
        //out.writeBytes(this.data);
        public override void Write(IMinecraftStreamWriter output)
        {

        }
    }
}
