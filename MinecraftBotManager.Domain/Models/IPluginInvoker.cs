using MinecraftBotManager.PluginContracts;

namespace MinecraftBotManagerWPF
{
    public interface IPluginInvoker
    {
        void Invoke(Action<IPlugin> action);
    }
}
