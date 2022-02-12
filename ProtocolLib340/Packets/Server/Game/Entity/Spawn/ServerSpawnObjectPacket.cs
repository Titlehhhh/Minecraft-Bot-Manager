using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity.Spawn
{

    [PacketHeader(0x00, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSpawnObjectPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.uuid = in.readUUID();
       //this.type = MagicValues.key(ObjectType.class, in.readByte());
       //this.x = in.readDouble();
       //this.y = in.readDouble();
       //this.z = in.readDouble();
       //this.pitch = in.readByte() * 360 / 256f;
       //this.yaw = in.readByte() * 360 / 256f;
       //
       //int data = in.readInt();
       //if(data > 0) {
       //if(this.type == ObjectType.MINECART) {
       //this.data = MagicValues.key(MinecartType.class, data);
       //} else if(this.type == ObjectType.ITEM_FRAME) {
       //this.data = MagicValues.key(HangingDirection.class, data);
       //} else if(this.type == ObjectType.FALLING_BLOCK) {
       //this.data = new FallingBlockData(data & 65535, data >> 16);
       //} else if(this.type == ObjectType.POTION) {
       //this.data = new SplashPotionData(data);
       //} else if(this.type == ObjectType.SPECTRAL_ARROW || this.type == ObjectType.TIPPED_ARROW || this.type == ObjectType.GHAST_FIREBALL || this.type == ObjectType.BLAZE_FIREBALL || this.type == ObjectType.DRAGON_FIREBALL || this.type == ObjectType.WITHER_HEAD_PROJECTILE || this.type == ObjectType.FISH_HOOK) {
       //this.data = new ProjectileData(data);
       //} else {
       //this.data = new ObjectData() {
       //};
       //}
       //}
       //
       //this.motX = in.readShort() / 8000D;
       //this.motY = in.readShort() / 8000D;
       //this.motZ = in.readShort() / 8000D;
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerSpawnObjectPacket() {}
    }

}
