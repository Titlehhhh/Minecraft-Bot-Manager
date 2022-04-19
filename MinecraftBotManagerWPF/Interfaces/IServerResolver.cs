using MinecraftLibrary.API;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IServerResolver
    {
        Task<bool> ResolveAsync(ref string host, ref ushort port);
    }
    public interface ILoginService
    {
        Task<LoginResult> LoginAsync(string nick,string pass, AccountType accountType);
    }
}
