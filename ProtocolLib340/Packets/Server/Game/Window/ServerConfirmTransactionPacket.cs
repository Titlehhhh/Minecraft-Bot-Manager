using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server.Game.Window
{

    
    public class ServerConfirmTransactionPacket : IPacket
    {
        //this.windowId = in.readUnsignedByte();
       //this.actionId = in.readShort();
       //this.accepted = in.readBoolean();
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerConfirmTransactionPacket() {}
    }

}
