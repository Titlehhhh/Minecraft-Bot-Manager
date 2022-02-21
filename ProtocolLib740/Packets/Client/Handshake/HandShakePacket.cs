using MinecraftLibrary.API.Enums;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProtocolLib740.Packets.Client.Handshake
{
    [PacketHeader(0x00, 740, PacketSide.Client, PacketCategory.HandShake)]
    public class HandShakePacket : IPacket
    {
        public HandShakeIntent Intent { get; set; }
        public int ProtocolVersion { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
        public void Write(MinecraftStream stream)
        {
            stream.WriteVarInt(ProtocolVersion);
            stream.WriteString(Host);
            stream.WriteUnsignedShort((ushort)Port);
            stream.WriteVarInt((int)Intent);
        }

        public void Read(MinecraftStream stream)
        {

        }

        public HandShakePacket(HandShakeIntent intent, int protocolVersion, int port, string host)
        {
            Intent = intent;
            ProtocolVersion = protocolVersion;
            Port = port;
            Host = host;
        }
    }
}
