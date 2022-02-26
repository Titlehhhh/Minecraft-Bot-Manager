using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Packets.Client.Login
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
