using MinecraftLibrary.API;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IServerResolver
    {
        Task<(string, ushort)> ResolveAsync(string host);
    }
    public interface ILoginService
    {
        Task<LoginResult> LoginAsync(string nick, string pass, AccountType accountType);
    }
}
