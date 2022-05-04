using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{

    [PacketInfo(0x07, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientConfirmTransactionPacket : IPacket
    {
        public byte WindowId { get; private set; }
        public ushort ActionId { get; private set; }
        public bool Accepted { get; private set; }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteUnsignedByte(WindowId);
            stream.WriteUnsignedLong(ActionId);
            stream.WriteBoolean(Accepted);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            WindowId = stream.ReadUnsignedByte();
            ActionId = stream.ReadUnsignedShort();
            Accepted = stream.ReadBoolean();
        }
        public ClientConfirmTransactionPacket() { }

        public ClientConfirmTransactionPacket(byte WindowId, ushort ActionId, bool Accepted)
        {
            this.WindowId = WindowId;
            this.ActionId = ActionId;
            this.Accepted = Accepted;
        }
    }
}
