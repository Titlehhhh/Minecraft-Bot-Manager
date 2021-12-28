using MinecraftLibrary.MinecraftProtocol.IO.Stream;
using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Client.Login
{
    public class EncryptionResponsePacket : ClientPacket
    {
        public byte[] verifytoken;
        public byte[] sharedkey;

        public EncryptionResponsePacket(byte[] verifytoken, byte[] sharedkey)
        {
            this.verifytoken = verifytoken;
            this.sharedkey = sharedkey;
        }

        public void Write(NetOutput output, int protocolversion)
        {
            output.WriteArray(StreamNetOutput.ConcatBytes(sharedkey, verifytoken));

        }
    }
}
