using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Game.World
{

    [PacketMeta(0x2A, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerOpenTileEntityEditorPacket : MinecraftPacket
    {
        //this.position = NetUtil.readPosition(in);
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerOpenTileEntityEditorPacket() {}
    }

}
