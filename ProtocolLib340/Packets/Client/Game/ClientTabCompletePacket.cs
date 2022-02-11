using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x01, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientTabCompletePacket : IPacket
    {
        //out.writeString(this.text);
       //out.writeBoolean(this.assumeCommand);
       //out.writeBoolean(this.lookingAt != null);
       //if(this.lookingAt != null) {
       //NetUtil.writePosition(out, this.lookingAt);
       //}
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
