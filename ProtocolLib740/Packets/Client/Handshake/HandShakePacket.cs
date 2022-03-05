
using MinecraftLibrary.API;
using MinecraftLibrary.API.IO;
using MinecraftLibrary.API.Networking;

namespace ProtocolLib754.Packets.Client
{
    [MinecraftLibrary.API.Protocol.PacketInfo(0x00, 740, PacketCategory.HandShake, PacketSide.Client)]
    public class HandShakePacket : IPacket
    {
        public HandShakeIntent Intent { get; set; }
        public int ProtocolVersion { get; set; }
        public ushort Port { get; set; }
        public string Host { get; set; }
        public void Write(IMinecraftStreamWriter stream)
        {
            stream.WriteVarInt(ProtocolVersion);
            stream.WriteString(Host);
            stream.WriteUnsignedShort(Port);
            stream.WriteVarInt((int)Intent);
        }

        public void Read(IMinecraftStreamReader stream)
        {

        }

        public HandShakePacket(HandShakeIntent intent, int protocolVersion, ushort port, string host)
        {
            Intent = intent;
            ProtocolVersion = protocolVersion;
            Port = port;
            Host = host;
        }
    }
}
