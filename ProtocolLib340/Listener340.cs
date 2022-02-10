using MinecraftLibrary.API.Common;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib340
{
    public class Listener340 : IPacketListener
    {
        public void Connected(IPacketProtocol session, string username)
        {
          
        }

        public void Disconnected(IPacketProtocol session)
        {
            throw new NotImplementedException();
        }

        public void HandlePacket(IPacketProtocol session, IPacket packet)
        {
            throw new NotImplementedException();
        }

        public void PacketSend(IPacketProtocol session, IPacket packet)
        {
            throw new NotImplementedException();
        }

        public void PacketSent(IPacketProtocol session, IPacket packet)
        {
            throw new NotImplementedException();
        }
    }

}
