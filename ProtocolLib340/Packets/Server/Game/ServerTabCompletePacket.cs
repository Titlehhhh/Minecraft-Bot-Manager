using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketMeta(0x0E, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerTabCompletePacket : MinecraftPacket
    {
        //this.matches = new String[in.readVarInt()];
       //for(int index = 0; index < this.matches.length; index++) {
       //this.matches[index] = in.readString();
       //}
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerTabCompletePacket() {}
    }

}
