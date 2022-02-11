using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.World
{

    [PacketInfo(0x1E, 340, PacketSide.Server, PacketCategory.Game)]
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
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerNotifyClientPacket() {}
    }

}
