namespace MinecraftBotManager.Contracts.Services
{
    public interface ISerializationService
    {
        TValue Deserialize<TValue>(string path, params object[] constructorArgs);
        void Serialize<TValue>(TValue item, string path);
    }
}
