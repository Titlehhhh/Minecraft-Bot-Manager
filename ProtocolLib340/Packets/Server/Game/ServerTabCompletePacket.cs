using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x0E, 340, PacketSide.Server, PacketCategory.Game)]
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
