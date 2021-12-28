

using MinecraftProtocol.IO;

namespace MinecraftProtocol.Packets
{
    public interface ClientPacket
    {
        void Write(NetOutput output, int protocolversion);
    }
    public interface ServerPacket
    {
        void Read(NetInput input, int protocovesrion);
    }
}
