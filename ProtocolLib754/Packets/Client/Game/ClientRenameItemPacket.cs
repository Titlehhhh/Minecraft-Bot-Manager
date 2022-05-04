using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{

    [PacketInfo(0x20, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientRenameItemPacket : IPacket
    {
        public string Name { get; private set; }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteString(Name);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            Name = stream.ReadString();
        }
        public ClientRenameItemPacket() { }

        public ClientRenameItemPacket(string Name)
        {
            this.Name = Name;
        }
    }
}
