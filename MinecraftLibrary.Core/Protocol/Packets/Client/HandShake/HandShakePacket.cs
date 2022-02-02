using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.API.Protocol.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Protocol.Packets.Client.HandShake
{
    [PacketMetaHandShake(0x00)]
    public class HandShakePacket : ClientPacket
    {
        public HandShakeIntent Intent { get; set; }
        public int ProtocolVersion { get; set; }
        public int Port { get; set; }
        public string Hostname { get; set; }
        public override void Write(MinecraftStream output, int version)
        {
            output.WriteVarInt(this.ProtocolVersion);
            output.WriteString(Hostname);
            output.WriteUShort((ushort)Port);
            output.WriteVarInt((int)Intent);
        }

        public HandShakePacket(HandShakeIntent intent, int protocolVersion, int port, string hostname)
        {
            Intent = intent;
            ProtocolVersion = protocolVersion;
            Port = port;
            Hostname = hostname;
        }
    }
    public enum HandShakeIntent : int
    {
        STATUS = 1,
        LOGIN = 2
    }

}
