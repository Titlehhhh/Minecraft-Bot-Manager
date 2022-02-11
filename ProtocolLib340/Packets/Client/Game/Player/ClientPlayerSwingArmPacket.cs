using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x1D, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerSwingArmPacket : IPacket
    {
        //out.writeVarInt(MagicValues.value(Integer.class, this.hand));
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
