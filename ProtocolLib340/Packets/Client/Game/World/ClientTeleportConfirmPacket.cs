using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Client.Game.World
{

    [PacketInfo(0x00, 340, PacketSide.Client, PacketCategory.Game)]
    public class ClientTeleportConfirmPacket : MinecraftPacket
    {
        public int ID { get; set; }

        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteVarInt(ID);
        }

        public ClientTeleportConfirmPacket(int iD)
        {
            ID = iD;
        }
    }
}
