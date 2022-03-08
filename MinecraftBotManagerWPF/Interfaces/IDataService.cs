using MinecraftBotManagerWPF.Models;
using System.Collections.Generic;

namespace MinecraftBotManagerWPF.Interfaces
{
    public delegate void AddBotHandler(Bot newbot);
    public interface IBotRepository
    {
        void AddBot(Bot bot);
        void RemoveBot(Bot bot);
        void Save();

        IEnumerable<Bot> GetAllBots();

        event AddBotHandler AddBotEvent;
    }
    public interface IDataService
    {
        IBotRepository BotRepository { get; }
        void Save();
    }
}
