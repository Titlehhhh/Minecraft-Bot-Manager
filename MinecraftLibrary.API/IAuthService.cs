using System.Threading.Tasks;
using System;

namespace MinecraftLibrary.API
{
    public interface IAuthService
    {
        Task<LoginResult> AuthAsync(string login, string password,out GameProfile gameProfile);
    }    
    
}
