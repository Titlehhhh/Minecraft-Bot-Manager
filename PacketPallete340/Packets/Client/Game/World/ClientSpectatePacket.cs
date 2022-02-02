using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.World
{
    //out.writeUUID(this.target);
    [PacketMeta(0x1E, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSpectatePacket : ClientPacket
    {
        public override void Write(MinecraftStream output, int version)
        {
            
        }
    }
}
