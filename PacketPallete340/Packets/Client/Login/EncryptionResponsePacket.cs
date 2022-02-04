using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Attributes;
using MinecraftLibrary.API.Protocol.Helpres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacketPallete340.Packets.Client.Login
{
    [PacketMeta(0x01, 340, PacketSide.Client, PacketCategory.Login)]
    public class EncryptionResponsePacket : MinecraftPacket
    {
        public byte[] VerifyToken { get; set; }
        public byte[] SharedKey { get; set; }

        public EncryptionResponsePacket(byte[] verifyToken, byte[] sharedKey)
        {
            VerifyToken = verifyToken;
            SharedKey = sharedKey;
        }
        public override void Write(MinecraftStream output)
        {
            output.WriteArray(SharedKey);
            output.WriteArray(VerifyToken);
        }
    }
}
