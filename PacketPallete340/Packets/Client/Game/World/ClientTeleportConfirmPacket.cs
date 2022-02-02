using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.World
{

    [PacketMeta(0x00, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientTeleportConfirmPacket : ClientPacket
    {
        public int ID { get; set; }

        public override void Write(MinecraftStream output)
        {
            output.WriteVarInt(ID);
        }

        public ClientTeleportConfirmPacket(int iD)
        {
            ID = iD;
        }
    }
}
