using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Packets.Client.Login
{
    [PacketInfo(0x01, 340, PacketSide.Client, PacketCategory.Login)]
    public class EncryptionResponsePacket : IPacket
    {
        public byte[] VerifyToken { get; set; }
        public byte[] SharedKey { get; set; }

        public EncryptionResponsePacket(byte[] verifyToken, byte[] sharedKey)
        {
            VerifyToken = verifyToken;
            SharedKey = sharedKey;
        }
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteArray(SharedKey);
            output.WriteArray(VerifyToken);
        }
    }
}
