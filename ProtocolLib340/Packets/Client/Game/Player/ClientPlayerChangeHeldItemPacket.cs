using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x1A, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerChangeHeldItemPacket : MinecraftPacket
    {
        //out.writeShort(this.slot);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
