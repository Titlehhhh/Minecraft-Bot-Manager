using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x01, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientTabCompletePacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeString(this.text);
        //out.WriteBooleanean(this.assumeCommand);
        //out.WriteBooleanean(this.lookingAt != null);
        //if(this.lookingAt != null) {
        //NetUtil.writePosition(out, this.lookingAt);
        //}
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
