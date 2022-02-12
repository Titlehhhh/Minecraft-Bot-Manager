using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketHeader(0x0E, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerTabCompletePacket : IPacket
    {
        //this.matches = new String[in.readVarInt()];
       //for(int index = 0; index < this.matches.length; index++) {
       //this.matches[index] = in.readString();
       //}
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerTabCompletePacket() {}
    }

}
