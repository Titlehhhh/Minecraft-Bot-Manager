using MinecraftLibrary.API.IO;

namespace MinecraftLibrary.API.Networking
{
    public interface IPacket
    {
        void Read(IMinecraftStreamReader stream);
        void Write(IMinecraftStreamWriter stream);
    }
}
