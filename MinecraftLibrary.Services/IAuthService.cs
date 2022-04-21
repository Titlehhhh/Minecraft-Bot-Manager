using MinecraftLibrary.API;

namespace MinecraftLibrary.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> AuthAsync(AuthInfo authInfo, out GameProfile gameProfile);
    }
}