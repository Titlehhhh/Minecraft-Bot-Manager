using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{

    [PacketMeta(0x01, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientTabCompletePacket : MinecraftPacket
    {
        //out.writeString(this.text);
       //out.writeBoolean(this.assumeCommand);
       //out.writeBoolean(this.lookingAt != null);
       //if(this.lookingAt != null) {
       //NetUtil.writePosition(out, this.lookingAt);
       //}
        public override void Write(MinecraftStream output)
        {
            
        }
    }
}
