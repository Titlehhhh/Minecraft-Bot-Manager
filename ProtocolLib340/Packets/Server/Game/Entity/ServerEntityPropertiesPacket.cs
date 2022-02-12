using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x4E, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityPropertiesPacket : IPacket
    {
        //this.entityId = in.readVarInt();
       //this.attributes = new ArrayList<Attribute>();
       //int length = in.readInt();
       //for(int index = 0; index < length; index++) {
       //String key = in.readString();
       //double value = in.readDouble();
       //List<AttributeModifier> modifiers = new ArrayList<AttributeModifier>();
       //int len = in.readVarInt();
       //for(int ind = 0; ind < len; ind++) {
       //modifiers.add(new AttributeModifier(in.readUUID(), in.readDouble(), MagicValues.key(ModifierOperation.class, in.readByte())));
       //}
       //
       //this.attributes.add(new Attribute(MagicValues.key(AttributeType.class, key), value, modifiers));
       //}
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityPropertiesPacket() {}
    }

}
