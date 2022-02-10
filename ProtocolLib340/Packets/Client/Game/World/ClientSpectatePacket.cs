using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketInfo(0x1E, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientSpectatePacket : MinecraftPacket
    {
        //out.writeUUID(this.target);
        public override void Write(IMinecraftStreamWriter output)
        {
            
        }
    }
}
