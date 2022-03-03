using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib740.Packets.Server
{
    [PacketInfo(0x01, 740, PacketCategory.Game, PacketSide.Server)]
    public class EncryptionRequestPacket : IPacket
    {
        public string ServerID { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] VerifyToken { get; set; }

        public void Read(IMinecraftStreamReader stream)
        {
            ServerID = stream.ReadString();

            PublicKey = stream.ReadUInt8Array();
            VerifyToken = stream.ReadUInt8Array();

        }

        public void Write(IMinecraftStreamWriter stream)
        {

        }
        public EncryptionRequestPacket()
        {

        }
    }
}
