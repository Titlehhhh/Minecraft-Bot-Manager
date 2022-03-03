using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;


namespace ProtocolLib340.Packets.Server
{

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

        public EncryptionRequestPacket(string serverID, byte[] publicKey, byte[] verifyToken)
        {
            ServerID = serverID;
            PublicKey = publicKey;
            VerifyToken = verifyToken;
        }
    }
}
