using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientSettingsPacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        //out.writeString(this.locale);
        //out.writeByte(this.renderDistance);
        //out.writeVarInt(MagicValues.value(Integer.class, this.chatVisibility));
        //out.WriteBooleanean(this.chatColors);
        //
        //int flags = 0;
        //for(SkinPart part : this.visibleParts) {
        //flags |= 1 << part.ordinal();
        //}
        //
        //out.writeByte(flags);
        //
        //out.writeVarInt(MagicValues.value(Integer.class, this.mainHand));
        public void Write(IMinecraftStreamWriter stream)
        {

        }
    }
}
