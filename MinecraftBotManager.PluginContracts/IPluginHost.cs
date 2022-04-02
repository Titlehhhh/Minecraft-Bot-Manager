namespace MinecraftBotManager.PluginContracts
{
    public interface IPluginHost
    {
        List<IPlugin> Plugins { get; }

        void Add(IPlugin plugin);
        void Remove(IPlugin plugin);
        void Invoke(Action<IPlugin> action);

        event PluginHandler? PluginLoaded;
        event PluginHandler? PluginUnLoaded;
    }
}