using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;


namespace ProtocolLib754.Packets.Client
{

    [PacketInfo(0x19, 754, PacketCategory.Game, PacketSide.Client)]
    public class ClientPrepareCraftingGridPacket : IPacket
    {
        public byte WindowId { get; private set; }
        public string RecipeId { get; private set; }
        public bool MakeAll { get; private set; }

        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteUnsignedByte(WindowId);
            stream.WriteString(RecipeId);
            stream.WriteBoolean(MakeAll);
        }
        public void Read(IMinecraftStreamReader stream)
        {
            WindowId = stream.ReadUnsignedByte();
            RecipeId = stream.ReadString();
            MakeAll = stream.ReadBoolean();
        }
        public ClientPrepareCraftingGridPacket() { }

        public ClientPrepareCraftingGridPacket(byte WindowId, string RecipeId, bool MakeAll)
        {
            this.WindowId = WindowId;
            this.RecipeId = RecipeId;
            this.MakeAll = MakeAll;
        }
    }
}
