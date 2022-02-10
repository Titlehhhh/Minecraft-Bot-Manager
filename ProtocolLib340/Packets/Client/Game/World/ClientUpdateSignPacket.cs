using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketInfo(0x1C, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientUpdateSignPacket : MinecraftPacket
    {
        //NetUtil.writePosition(out, this.position);
       //for(String line : this.lines) {
       //out.writeString(line);
       //}
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
