using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game
{

    [PacketInfo(0x18, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientResourcePackStatusPacket : MinecraftPacket
    {
        //out.writeVarInt(MagicValues.value(Integer.class, this.status));
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
