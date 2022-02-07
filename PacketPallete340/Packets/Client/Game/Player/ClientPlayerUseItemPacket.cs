using MinecraftLibrary.API;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Client.Game.Player
{

    [PacketMeta(0x20, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerUseItemPacket : MinecraftPacket
    {
        public HAND Hand { get; set; }
        public int MyProperty { get; set; }        
        public override void Write(IMinecraftStreamWriter output)
        {
            switch (Hand)
            {
                case HAND.MAINHAND:
                    output.WriteVarInt(0);
                    break;
                case HAND.OFFHAND:
                    output.WriteVarInt(1);
                    break;
            }
        }

        public ClientPlayerUseItemPacket(HAND hand, int myProperty)
        {
            Hand = hand;
            MyProperty = myProperty;
        }
    }
}
