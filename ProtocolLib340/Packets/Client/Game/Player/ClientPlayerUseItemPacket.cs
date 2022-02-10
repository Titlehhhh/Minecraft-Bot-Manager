using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x20, 340, PacketSide.Client, PacketCategory.Game)]
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
