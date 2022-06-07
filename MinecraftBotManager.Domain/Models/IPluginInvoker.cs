namespace MinecraftBotManager.Domain
{
    public interface IPluginInvoker
    {
        void Invoke(Action<IPlugin> action);
    }
}
