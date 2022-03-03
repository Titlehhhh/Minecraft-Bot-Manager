using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Client.Game
{


    public class ClientPlayerUseItemPacket : IPacket
    {
        public HAND Hand { get; set; }
        public int MyProperty { get; set; }
        public void Write(IMinecraftStreamWriter stream)
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

        public void Read(IMinecraftStreamReader stream)
        {

        }

        public ClientPlayerUseItemPacket(HAND hand, int myProperty)
        {
            Hand = hand;
            MyProperty = myProperty;
        }
    }
}
