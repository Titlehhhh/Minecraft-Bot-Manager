using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{
    //out.writeString(this.text);
    //out.writeBoolean(this.assumeCommand);
    //out.writeBoolean(this.lookingAt != null);
    //if(this.lookingAt != null) {
    //NetUtil.writePosition(out, this.lookingAt);
    //}
    [PacketMeta(0x01, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientTabCompletePacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
