using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientPlayerStatePacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        //out.writeVarInt(this.entityId);
        //out.writeVarInt(MagicValues.value(Integer.class, this.state));
        //out.writeVarInt(this.jumpBoost);
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
    }
}
