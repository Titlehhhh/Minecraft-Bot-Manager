using MinecraftBotManager.Api.Services;

namespace MinecraftBotManager.Api
{
    public interface IMinecraftBotManager
    {
        IBotRepository BotRepository { get; }
    }
}