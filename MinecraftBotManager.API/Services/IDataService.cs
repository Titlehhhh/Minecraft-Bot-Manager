namespace MinecraftBotManager.Core
{

    public interface IDataService
    {
        IBotRepository BotRepository { get; }
        IPluginRepository PluginRepository { get; }
        IProxyRepository ProxyRepository { get; }
        void Save();
    }
}
