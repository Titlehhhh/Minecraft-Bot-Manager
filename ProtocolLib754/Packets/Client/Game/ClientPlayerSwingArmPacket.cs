using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{

    [PacketInfo(0x2C, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientPlayerSwingArmPacket : IPacket
    {
        public Hand PlayerHand { get; private set; }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteVarInt(PlayerHand);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            PlayerHand = (Hand)stream.ReadVarInt();
        }
        public ClientPlayerSwingArmPacket() { }

        public ClientPlayerSwingArmPacket(Hand PlayerHand)
        {
            this.PlayerHand = PlayerHand;
        }
    }
}
