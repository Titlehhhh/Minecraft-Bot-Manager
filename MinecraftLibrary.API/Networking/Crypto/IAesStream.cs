namespace MinecraftLibrary.API.Networking.Crypto
{
    public interface IAesStream
    {
        int Read(byte[] buffer, int offset, int count);
        void Write(byte[] buffer, int offset, int count);
    }
}
