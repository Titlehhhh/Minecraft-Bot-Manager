
using MinecraftBotManager.Contracts.Services;
using MinecraftBotManager.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Storage;

namespace MinecraftBotManager.Services
{
    public sealed class BotRepository : IBotRepository
    {
        private List<ConnectionSettings> bots = new();

        private static readonly string LocalPath = ApplicationData.Current.LocalFolder.Path;

        private static readonly string CachedIconPath = Path.Combine(LocalPath, "CachedIcons");
        private static readonly string PathBots = Path.Combine(ApplicationData.Current.LocalFolder.Path, "Bots.json");

        public IEnumerable<ConnectionSettings> GetAllBots() => bots;

        public void Add(ConnectionSettings bot)
        {
            bots.Add(bot);
        }
        public bool Remove(ConnectionSettings bot)
        {
            return bots.Remove(bot);
        }
        public bool Remove(Guid id)
        {
            return bots.Remove(bots.FirstOrDefault(b => b.Id == id));
        }


        private bool inizialized = false;

        private static readonly object fileLock = new();

        public async Task Save()
        {
            if (inizialized)
            {
                await Task.Run(() =>
                {
                    lock (fileLock)
                    {
                        serializationService.Serialize(bots, PathBots);
                    }
                });
            }

        }
        public async Task InizializeAsync()
        {

            if (!inizialized)
            {
                await Task.Run(() =>
                {
                    lock (fileLock)
                    {
                        bots = serializationService.Deserialize<List<ConnectionSettings>>(PathBots);
                    }
                });


                inizialized = true;
            }

        }
        private readonly ISerializationService serializationService;

        public BotRepository(ISerializationService serializationService)
        {
            this.serializationService = serializationService;
        }


    }
}
