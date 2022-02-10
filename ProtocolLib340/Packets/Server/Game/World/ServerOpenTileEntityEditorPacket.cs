using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x2A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerOpenTileEntityEditorPacket : MinecraftPacket
    {
        //this.position = NetUtil.readPosition(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerOpenTileEntityEditorPacket() {}
    }

}
