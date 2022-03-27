using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;

namespace ProtocolLib754.Packets.Client
{
    [MinecraftLibrary.API.Protocol.PacketInfo(0x01, 740, PacketCategory.Login, PacketSide.Client)]
    public class EncryptionResponsePacket : IPacket
    {
        public byte[] VerifyToken { get; set; }
        public byte[] SharedKey { get; set; }

        public EncryptionResponsePacket(byte[] sharedKey, byte[] verifyToken)
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
