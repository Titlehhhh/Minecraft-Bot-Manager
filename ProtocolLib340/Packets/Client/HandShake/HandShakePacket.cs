using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.IO;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Packets.Client.HandShake
{
    
    public class HandShakePacket : IPacket
    {
        public HandShakeIntent Intent { get; set; }
        public int ProtocolVersion { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteVarInt(ProtocolVersion);
            stream.WriteString(Host);
            stream.WriteUnsignedShort((ushort)Port);
            stream.WriteVarInt((int)Intent);
        }

        public void Read(IMinecraftStreamReader stream)
        {

        }
        public HandShakePacket() { }
        public HandShakePacket(HandShakeIntent intent, int protocolVersion, int port, string host)
        {
            Intent = intent;
            ProtocolVersion = protocolVersion;
            Port = port;
            Host = host;
        }
    }
}
