
using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;

namespace ProtocolLib740.Packets.Client
{
    [MinecraftLibrary.API.Protocol.PacketInfo(0x00, 740, PacketCategory.HandShake, PacketSide.Client)]
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

        public HandShakePacket(HandShakeIntent intent, int protocolVersion, int port, string host)
        {
            Intent = intent;
            ProtocolVersion = protocolVersion;
            Port = port;
            Host = host;
        }
    }
}
