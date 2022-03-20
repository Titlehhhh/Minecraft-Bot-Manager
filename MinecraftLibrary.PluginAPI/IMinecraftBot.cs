using MinecraftLibrary.API;

namespace MinecraftLibrary.PluginAPI
{
    public interface IMinecraftBot : IDisposable
    {
        IProtocolClient ProtocolClient { get; }

        Task StartBotAsync();
        Task StopBotAsync();
    }
}
