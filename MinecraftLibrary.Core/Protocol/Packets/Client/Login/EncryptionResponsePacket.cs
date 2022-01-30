using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.Core.Protocol.Attributes;

namespace MinecraftLibrary.Core.Protocol.Packets.Client.Login
{
    [PacketMetaLogin(0x01)]
    public class EncryptionResponsePacket : ClientPacket
    {
        public byte[] VerifyToken;
        public byte[] SharedKey;

        public EncryptionResponsePacket(byte[] verifytoken, byte[] sharedkey)
        {
            this.VerifyToken = verifytoken;
            this.SharedKey = sharedkey;
        }
        public override void Write(MinecraftStream output, int protocolversion)
        {
            output.WriteArray(SharedKey);
            output.WriteArray(VerifyToken);
        }
    }
}
