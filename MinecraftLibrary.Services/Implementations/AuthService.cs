using MinecraftLibrary.API;

namespace MinecraftLibrary.Services
{
    public class AuthService : IAuthService
    {
        public Task<LoginResponse> AuthAsync(AuthInfo authInfo, out GameProfile gameProfile)
        {
            throw new NotImplementedException();
        }
    }
}