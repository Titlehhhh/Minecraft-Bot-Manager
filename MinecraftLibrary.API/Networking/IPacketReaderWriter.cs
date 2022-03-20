using MinecraftLibrary.API.IO;

namespace MinecraftLibrary.API.Networking
{
    public interface IPacketReaderWriter : IDisposable
    {
        NetworkMinecraftStream NetStream { get; }
        int CompressionThreshold { set; }
        Task WritePacketAsync(IPacket packet, int id);
        Task<(int, MinecraftStream)> ReadNextPacketAsync();
    }
}
