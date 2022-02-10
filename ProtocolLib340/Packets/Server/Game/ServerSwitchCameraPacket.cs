using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Game
{

    [PacketInfo(0x39, 340, PacketSide.Server, PacketCategory.Game)]
    public class ServerSwitchCameraPacket : MinecraftPacket
    {
        //this.cameraEntityId = in.readVarInt();
        public override void Read(IMinecraftStreamReader input)
        {
            
        }
        public ServerSwitchCameraPacket() {}
    }

}
