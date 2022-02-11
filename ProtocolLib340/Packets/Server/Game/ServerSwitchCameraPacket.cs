using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x39, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSwitchCameraPacket : IPacket
    {
        //this.cameraEntityId = in.readVarInt();
        public void Read(MinecraftStream stream)
        {
            
        }

        public void Write(MinecraftStream stream)
        {
            
        }

        public ServerSwitchCameraPacket() {}
    }

}
