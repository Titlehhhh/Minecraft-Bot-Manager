using MinecraftLibrary.API.Networking;

namespace MinecraftLibrary.API.Protocol
{
    public interface IPacketProvider : IPacketReader, IPacketWriter,ITcpClientSession
    {
       
    }

}
