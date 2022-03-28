using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public interface IServerResolver
    {
        Task<bool> ResolveAsync(ref string host, ref ushort port);
    }
}
