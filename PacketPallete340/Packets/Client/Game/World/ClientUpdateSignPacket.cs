using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.World
{
    //NetUtil.writePosition(out, this.position);
    //for(String line : this.lines) {
    //out.writeString(line);
    //}
    [PacketMeta(0x1C, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientUpdateSignPacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
