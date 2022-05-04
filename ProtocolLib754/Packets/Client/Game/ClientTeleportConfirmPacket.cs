using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{
    
    [PacketInfo(0x00, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientTeleportConfirmPacket : IPacket
    {
        public int Id {get; private set; }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteVarInt(Id);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            Id = stream.ReadVarInt();
        }
        public ClientTeleportConfirmPacket() { }

        public ClientTeleportConfirmPacket(int Id)
        {
            this.Id = Id;
        }
    }
}
