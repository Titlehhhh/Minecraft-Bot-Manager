using MinecraftLibrary.API;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game
{

    [PacketMeta(0x03, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientRequestPacket : MinecraftPacket
    {
        public ClientRequest Request { get; set; }
        //out.writeVarInt(MagicValues.value(Integer.class, this.request));
        public override void Write(MinecraftStream output)
        {
            output.WriteVarInt((int)Request);
        }
        public ClientRequestPacket()
        {

        }
        public ClientRequestPacket(ClientRequest request)
        {
            Request = request;
        }
    }
}
