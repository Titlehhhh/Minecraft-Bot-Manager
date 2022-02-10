using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Login
{
    [PacketInfo(0x01, 340, PacketSide.Server, PacketCategory.Login)]
    public class EncryptionRequestPacket : MinecraftPacket
    {
        public string ServerID { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] VerifyToken { get; set; }
        public override void Read(IMinecraftStreamReader input)
        {
            ServerID = input.ReadNextString();
            PublicKey = input.ReadNextByteArray();
            VerifyToken = input.ReadNextByteArray();
        }
        public EncryptionRequestPacket()
        {

        }

        public EncryptionRequestPacket(string serverID, byte[] publicKey, byte[] verifyToken)
        {
            ServerID = serverID;
            PublicKey = publicKey;
            VerifyToken = verifyToken;
        }
    }
}
