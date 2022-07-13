﻿using MinecraftBotManager.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Contracts.Services
{
    public interface IBotRepository
    {
        void Add(BotInfo bot);
        IEnumerable<BotInfo> GetAllBots();
        Task InizializeAsync();
        bool Remove(BotInfo bot);
        bool Remove(Guid id);
        Task Save();
    }
}
