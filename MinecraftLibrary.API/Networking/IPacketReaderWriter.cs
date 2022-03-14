using MinecraftLibrary.API.IO;

namespace MinecraftLibrary.API.Networking
{
    public interface IPacketReaderWriter : IDisposable
    {
        NetworkMinecraftStream NetworkStream { get; }

        int CompressionThreshold { get; set; }
        Task WritePacketAsync(IPacket packet, int id);
        Task<(int, MinecraftStream)> ReadNextPacketAsync();
    }
}
