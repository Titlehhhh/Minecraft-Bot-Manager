namespace MinecraftBotManager.API
{
    public interface IDialogService
    {
        Task<bool?> ShowDialog(string quest);

    }
}
