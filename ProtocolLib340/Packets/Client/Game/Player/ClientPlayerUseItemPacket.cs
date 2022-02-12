using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketHeader(0x20, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerUseItemPacket : IPacket
    {
        public HAND Hand { get; set; }
        public int MyProperty { get; set; }        
        public void Write(MinecraftStream stream)
        {
            switch (Hand)
            {
                case HAND.MAINHAND:
                    stream.WriteVarInt(0);
                    break;
                case HAND.OFFHAND:
                    stream.WriteVarInt(1);
                    break;
            }
        }

        public void Read(MinecraftStream stream)
        {
            
        }

        public ClientPlayerUseItemPacket(HAND hand, int myProperty)
        {
            Hand = hand;
            MyProperty = myProperty;
        }
    }
}
