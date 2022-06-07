namespace MinecraftBotManager.API
{

    public interface IDataService
    {
        IBotRepository BotRepository { get; }
        IPluginRepository PluginRepository { get; }
        IProxyRepository ProxyRepository { get; }
        void Save();
    }
}
