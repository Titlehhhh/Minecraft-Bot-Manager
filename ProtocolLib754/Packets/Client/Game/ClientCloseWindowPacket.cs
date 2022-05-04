using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{

    [PacketInfo(0x0A, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientCloseWindowPacket : IPacket
    {
        public byte WindowId { get; private set; }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteUnsignedByte(WindowId);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            WindowId = stream.ReadUnsignedByte();
        }
        public ClientCloseWindowPacket() { }

        public ClientCloseWindowPacket(byte WindowId)
        {
            this.WindowId = WindowId;
        }
    }
}
