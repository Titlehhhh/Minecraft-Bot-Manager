namespace MinecraftLibrary.API
{
    public interface IAuthService
    {
        Task<LoginResult> AuthAsync(AuthInfo authInfo, out GameProfile gameProfile);
    }

}
