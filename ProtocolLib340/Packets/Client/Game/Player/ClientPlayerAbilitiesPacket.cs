using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Client.Game
{

    
    public class ClientPlayerAbilitiesPacket : IPacket
    {
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        //byte flags = 0;
        //if(this.invincible) {
        //flags = (byte) (flags | 1);
        //}
        //
        //if(this.canFly) {
        //flags = (byte) (flags | 2);
        //}
        //
        //if(this.flying) {
        //flags = (byte) (flags | 4);
        //}
        //
        //if(this.creative) {
        //flags = (byte) (flags | 8);
        //}
        //
        //out.writeByte(flags);
        //out.writeFloat(this.flySpeed);
        //out.writeFloat(this.walkSpeed);
        public void Write(IMinecraftStreamWriter stream)
        {
            
        }
    }
}
