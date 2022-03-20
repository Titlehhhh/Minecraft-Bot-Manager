using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{

    [PacketInfo(0x2F, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientPlayerUseItemPacket : IPacket
    {
        public HAND Hand { get; set; }
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteVarInt(Hand);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            Hand = (HAND)stream.ReadVarInt();
        }
        public ClientPlayerUseItemPacket() { }
    }
}

