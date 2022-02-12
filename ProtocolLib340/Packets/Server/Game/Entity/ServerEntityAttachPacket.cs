using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game.Entity
{

    [PacketHeader(0x3D, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerEntityAttachPacket : IPacket
    {
        //this.entityId = in.readInt();
       //this.attachedToId = in.readInt();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerEntityAttachPacket() {}
    }

}
