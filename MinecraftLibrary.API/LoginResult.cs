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
}
