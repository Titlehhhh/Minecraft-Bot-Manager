namespace MinecraftBotManager.Domain
{
    public delegate void PluginHandler(IPluginHost host, Type t);
    public interface IPluginHost
    {
        List<IPlugin> Plugins { get; }
        void Add(Type Tplugin);
        void Remove(Type Tplugin);
        event PluginHandler? PluginLoaded;
        event PluginHandler? PluginUnLoaded;
    }
}
