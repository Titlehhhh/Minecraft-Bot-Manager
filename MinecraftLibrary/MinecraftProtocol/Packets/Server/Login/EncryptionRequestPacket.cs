using MinecraftProtocol.IO;
using MinecraftProtocol.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.MinecraftProtocol.Packets.Server.Login
{
    public class EncryptionRequestPacket : ServerPacket
    {
        public string serverid;
        public byte[] verifytoken;
        public byte[] sharedkey;
        public void Read(NetInput input, int version)
        {
            serverid = input.ReadNextString();
            sharedkey = input.ReadNextByteArray();
            verifytoken = input.ReadNextByteArray();
        }

    }
}
