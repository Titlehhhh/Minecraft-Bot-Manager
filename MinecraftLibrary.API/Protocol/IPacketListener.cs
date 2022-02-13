using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketListener
    {
        void Connected(TcpClientSession session);
        void Disconnected(TcpClientSession session);
        void HandlePacket(TcpClientSession session, IPacket packet);
        void PacketSent(TcpClientSession session, IPacket packet);
        void PacketSend(TcpClientSession session, IPacket packet);


    }
}
