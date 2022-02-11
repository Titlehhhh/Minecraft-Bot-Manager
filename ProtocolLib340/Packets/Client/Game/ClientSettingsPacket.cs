using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x04, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSettingsPacket : IPacket
    {
        //out.writeString(this.locale);
        //out.writeByte(this.renderDistance);
        //out.writeVarInt(MagicValues.value(Integer.class, this.chatVisibility));
        //out.writeBoolean(this.chatColors);
        //
        //int flags = 0;
        //for(SkinPart part : this.visibleParts) {
        //flags |= 1 << part.ordinal();
        //}
        //
        //out.writeByte(flags);
        //
        //out.writeVarInt(MagicValues.value(Integer.class, this.mainHand));
        public override void Write(IMinecraftStreamWriter output)
        {

        }
    }
}
