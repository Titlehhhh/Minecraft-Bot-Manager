using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    internal interface IServerResolver
    {
        Task<bool> ResolveAsync(ref string host, ref ushort port);
    }
}
