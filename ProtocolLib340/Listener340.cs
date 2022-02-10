using MinecraftLibrary.API.Common;
using MinecraftLibrary.API.Protocol;

namespace ProtocolLib340
{
    public class Listener340 : IPacketListener
    {
        public event Action LoginSucces;
        public event Action<string> LoginFailed;
        public event Action<string> ServerDisconnect;

        public void Connected(IPacketProvider session, string username)
        {
            
        }

        public void Disconnected(IPacketProvider session)
        {
            throw new NotImplementedException();
        }

        public void HandlePacket(IPacketProvider session, IPacket packet)
        {
            throw new NotImplementedException();
        }

        public void PacketSend(IPacketProvider session, IPacket packet)
        {
            throw new NotImplementedException();
        }

        public void PacketSent(IPacketProvider session, IPacket packet)
        {
            throw new NotImplementedException();
        }
    }

}
