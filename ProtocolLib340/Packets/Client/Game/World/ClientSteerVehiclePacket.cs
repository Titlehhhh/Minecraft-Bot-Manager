using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Client.Game
{


    public class ClientSteerVehiclePacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {

        }

        //out.writeFloat(this.sideways);
        //out.writeFloat(this.forward);
        //byte flags = 0;
        //if(this.jump) {
        //flags = (byte) (flags | 1);
        //}
        //
        //if(this.dismount) {
        //flags = (byte) (flags | 2);
        //}
        //
        //out.writeByte(flags);
        public void Write(IMinecraftStreamWriter stream)
        {

        }
    }
}
