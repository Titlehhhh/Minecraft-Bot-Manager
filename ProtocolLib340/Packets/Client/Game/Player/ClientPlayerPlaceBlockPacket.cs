using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x1F, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerPlaceBlockPacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //NetUtil.writePosition(out, this.position);
        //out.writeVarInt(MagicValues.value(Integer.class, this.face));
        //out.writeVarInt(MagicValues.value(Integer.class, this.hand));
        //out.writeFloat(this.cursorX);
        //out.writeFloat(this.cursorY);
        //out.writeFloat(this.cursorZ);
        public void Write(MinecraftStream stream)
        {

        }
    }
}
