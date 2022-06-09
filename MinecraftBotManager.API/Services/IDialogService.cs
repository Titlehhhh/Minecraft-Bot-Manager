namespace MinecraftBotManager.Core
{
    public interface IDialogService
    {
        Task<bool?> ShowDialog(string quest);

    }
}
