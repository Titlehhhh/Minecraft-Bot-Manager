using MinecraftBotManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftBotManager.Contracts.Services
{

    public delegate void BotAddedHandler(Bot bot);
    public delegate void BotRemovedHandler(Bot bot);

    public interface IBotList
    {
        IEnumerable<Bot> Bots { get; }

        void Add(Bot bot);
        bool Remove(Bot bot);
    }
}
