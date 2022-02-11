using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketInfo(0x00, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientTeleportConfirmPacket : IPacket
    {
        public int ID { get; set; }

        public void Write(MinecraftStream stream)
        {
            stream.WriteVarInt(ID);
        }

        public void Read(MinecraftStream stream)
        {
            
        }

        public ClientTeleportConfirmPacket(int iD)
        {
            ID = iD;
        }
    }
}
