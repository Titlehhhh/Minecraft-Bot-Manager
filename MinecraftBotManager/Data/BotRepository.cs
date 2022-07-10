
using MinecraftBotManager.Contracts.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace MinecraftBotManager.Data
{
    public sealed class BotRepository : IBotRepository
    {
        private List<BotRecord> bots = new();

        private static readonly string LocalPath = ApplicationData.Current.LocalFolder.Path;

        private static readonly string CachedIconPath = Path.Combine(LocalPath, "CachedIcons");
        private static readonly string PathBots = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Bots.json");

        public IEnumerable<BotRecord> GetAllBots() => bots;

        public void Add(BotRecord bot)
        {
            bots.Add(bot);
        }
        public bool Remove(BotRecord bot)
        {
            return bots.Remove(bot);
        }
        public bool Remove(Guid id)
        {
            return bots.Remove(bots.FirstOrDefault(b => b.Id == id));
        }

        
        private bool inizialized = false;

        private static readonly object fileLock = new();

        public Task Save()
        {
            if (inizialized)
            {
                lock (fileLock)
                {
                    serializationService.Serialize(bots, PathBots);
                }
            }
            return Task.CompletedTask;
        }
        public Task InizializeAsync()
        {
            if (!inizialized)
            {
                lock (fileLock)
                {
                    bots = serializationService.Deserialize<List<BotRecord>>(PathBots);
                }

                

                inizialized = true;
            }
            return Task.CompletedTask;
        }
        private readonly ISerializationService serializationService;

        public BotRepository(ISerializationService serializationService)
        {
            this.serializationService = serializationService;
        }


    }
}
