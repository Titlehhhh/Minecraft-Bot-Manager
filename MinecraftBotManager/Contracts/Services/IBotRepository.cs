using MinecraftBotManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Contracts.Services
{
    public delegate void BotAddedHandler(Bot bot);
    public delegate void BotRemovedHandler(Bot bot);

    public interface IBotRepository
    {
        IEnumerable<Bot> Bots { get; }

        void Add(Bot bot);
        bool Remove(Bot bot);
    }
}
