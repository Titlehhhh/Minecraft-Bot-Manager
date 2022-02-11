using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.Player
{

    [PacketInfo(0x15, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientPlayerStatePacket : IPacket
    {
        public void Read(MinecraftStream stream)
        {
            
        }

        //out.writeVarInt(this.entityId);
        //out.writeVarInt(MagicValues.value(Integer.class, this.state));
        //out.writeVarInt(this.jumpBoost);
        public void Write(MinecraftStream stream)
        {
            
        }
    }
}
