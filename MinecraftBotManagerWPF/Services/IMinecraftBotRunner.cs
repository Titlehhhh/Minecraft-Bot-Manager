using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IMinecraftBotRunner
    {
        Task PreparingAsync();
        Task<bool> AuthenticationAsync();
        Task<bool> ConfigureProxyAsync();
        Task<bool> ConfigureServerAsync();
        Task RunBotAsync();
    }
}
