using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;

namespace ProtocolLib340.Packets.Server.Login
{
    [PacketHeader(0x01, 340, PacketSide.Server, PacketCategory.Login)]
    public class EncryptionRequestPacket : IPacket
    {
        public string ServerID { get; set; }
        public byte[] PublicKey { get; set; }
        public byte[] VerifyToken { get; set; }
        public void Read(MinecraftStream stream)
        {           
            ServerID = stream.ReadString();
            PublicKey = stream.ReadUInt8Array();
            VerifyToken = stream.ReadUInt8Array();
        }

        public void Write(MinecraftStream stream)
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
