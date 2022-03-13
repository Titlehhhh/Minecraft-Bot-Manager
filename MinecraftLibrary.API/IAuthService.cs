namespace MinecraftLibrary.API
{
    public interface IAuthService
    {
        Task<LoginResult> AuthAsync(string login, string password, out GameProfile gameProfile);
    }

}
