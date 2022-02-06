using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;

namespace PacketPallete340.Packets.Server.Login
{
    [PacketMeta(0x01, 340, PacketSide.Server, PacketCategory.Login)]
    public class EncryptionRequestPacket : MinecraftPacket
    {
        public string ServerID { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] VerifyToken { get; set; }
        public override void Read(MinecraftStream input)
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
