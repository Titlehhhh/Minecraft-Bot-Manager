using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib340.Packets.Client.HandShake
{
    [PacketInfo(0x00,340,PacketSide.Client,PacketCategory.HandShake)]
    public class HandShakePacket : MinecraftPacket
    {
        public HandShakeIntent Intent { get; set; }
        public int ProtocolVersion { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public override void Write(IMinecraftStreamWriter output)
        {
            output.WriteVarInt(ProtocolVersion);
            output.WriteString(Host);
            output.WriteUShort((ushort)Port);
            output.WriteVarInt((int)Intent);
        }

        public HandShakePacket(HandShakeIntent intent, int protocolVersion, int port, string host)
        {
            Intent = intent;
            ProtocolVersion = protocolVersion;
            Port = port;
            Host = host;
        }
    }
    public enum HandShakeIntent : int
    {
        STATUS = 1,
        LOGIN = 2
    }
}
