using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{

    [PacketInfo(0x18, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientMoveItemToHotbarPacket : IPacket
    {
        public int Slot { get; private set; }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteVarInt(Slot);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            Slot = stream.ReadVarInt();
        }
        public ClientMoveItemToHotbarPacket() { }

        public ClientMoveItemToHotbarPacket(int Slot)
        {
            this.Slot = Slot;
        }
    }
}
