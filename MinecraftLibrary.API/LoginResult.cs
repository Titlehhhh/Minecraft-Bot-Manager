namespace MinecraftLibrary.API
{
    public enum LoginResult
    {
        OtherError,
        ServiceUnavailable,
        SSLError,
        Success,
        WrongPassword,
        AccountMigrated,
        NotPremium,
        LoginRequired,
        InvalidToken,
        InvalidResponse,
        NullError,
        UserCancel
    };
    public class LoginResponse
    {
        public string UUID { get; private set; }
        public LoginResult Result { get; private set; }
        public LoginResponse(string uuid,LoginResult result)
        {
            UUID = uuid;
            Result = result;
        }
    }
}
