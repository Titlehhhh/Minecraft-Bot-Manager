using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientConfirmTransactionPacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        //out.writeByte(this.windowId);
        //out.writeShort(this.actionId);
        //out.WriteBooleanean(this.accepted);
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
    }
}
