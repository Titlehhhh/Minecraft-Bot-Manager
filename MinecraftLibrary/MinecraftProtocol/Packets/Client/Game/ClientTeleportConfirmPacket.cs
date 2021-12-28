using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Game
{
    public class ClientTeleportConfirmPacket : ClientPacket
    {
        public int TeleportID { get; set; }
        public ClientTeleportConfirmPacket()
        {

        }
        public ClientTeleportConfirmPacket(int id)
        {
            TeleportID = id;
        }
        public void Write(NetOutput output, int version)
        {
            output.WriteVarInt(TeleportID);
        }
    }



}
