using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.World
{

    
    public class ServerOpenTileEntityEditorPacket : IPacket
    {
        //this.position = NetUtil.readPosition(in);
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerOpenTileEntityEditorPacket() {}
    }

}
