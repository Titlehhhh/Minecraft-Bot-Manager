using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x09, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPluginMessagePacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeString(this.channel);
        //out.writeBytes(this.data);
        public void Write(MinecraftStream stream)
        {

        }
    }
}
