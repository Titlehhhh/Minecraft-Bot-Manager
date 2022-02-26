using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;


namespace ProtocolLib740.Packets.Client.Login
{
    
    public class EncryptionResponsePacket : IPacket
    {
        public byte[] VerifyToken { get; set; }
        public byte[] SharedKey { get; set; }

        public EncryptionResponsePacket(byte[] verifyToken, byte[] sharedKey)
        {
            VerifyToken = verifyToken;
            SharedKey = sharedKey;
        }
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteVarInt(SharedKey.Length);
            stream.WriteByteArray(SharedKey);
            stream.WriteVarInt(VerifyToken.Length);
            stream.WriteByteArray(VerifyToken);
        }

        public void Read(IMinecraftStreamReader stream)
        {

        }
    }
}
