using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib340.Packets.Server
{

    
    public class ServerNotifyClientPacket : IPacket
    {
        //this.notification = MagicValues.key(ClientNotification.class, in.readUnsignedByte());
       //float value = in.readFloat();
       //if(this.notification == ClientNotification.CHANGE_GAMEMODE) {
       //this.value = MagicValues.key(GameMode.class, (int) value);
       //} else if(this.notification == ClientNotification.DEMO_MESSAGE) {
       //this.value = MagicValues.key(DemoMessageValue.class, (int) value);
       //} else if(this.notification == ClientNotification.ENTER_CREDITS) {
       //this.value = MagicValues.key(EnterCreditsValue.class, (int) value);
       //} else if(this.notification == ClientNotification.RAIN_STRENGTH) {
       //this.value = new RainStrengthValue(value);
       //} else if(this.notification == ClientNotification.THUNDER_STRENGTH) {
       //this.value = new ThunderStrengthValue(value);
       //}
        public void Read(IMinecraftStreamReader stream)
        {
            
        }

        public void Write(IMinecraftStreamWriter stream)
        {
            
        }

        public ServerNotifyClientPacket() {}
    }

}
