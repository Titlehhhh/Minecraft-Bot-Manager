using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public class BotRepository : IBotRepository
    {
        private static readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(MinecraftBot[]), settings);
        private static readonly DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings()
        {
            RootName = "Bots",
            UseSimpleDictionaryFormat = true,
        };

        public event AddBotHandler? AddBotEvent;

        private readonly List<MinecraftBot> Bots;

        public BotRepository()
        {
            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                string path = @"Database\bots.json";
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (FileStream fs = File.OpenRead(path))
                {
                    Bots = new List<MinecraftBot>(serializer.ReadObject(fs) as IEnumerable<MinecraftBot>);
                }
            }
            catch (Exception e)
            {
                //System.Windows.MessageBox.Show(e.ToString());
                this.Bots = new List<MinecraftBot>();
            }
        }

        public async Task AddBot(MinecraftBot bot)
        {
            Bots.Add(bot);
            AddBotEvent?.Invoke(bot);
            await Save();
        }

        public IEnumerable<MinecraftBot> GetAllBots()
        {
            return new List<MinecraftBot>(this.Bots);
        }

        public async Task RemoveBot(MinecraftBot bot)
        {
            this.Bots.Remove(bot);
            await Save();
        }

        private static readonly object FileLock = new object();

        public async Task Save()
        {
            await Task.Run(() =>
            {
                lock (FileLock)
                {
                    try
                    {
                        BinaryFormatter bin = new BinaryFormatter();
                        string path = @"Database\bots.json";
                        Directory.CreateDirectory(Path.GetDirectoryName(path));
                        using (FileStream fs = File.Open(path, FileMode.Create))
                        {
                            using (var writer = JsonReaderWriterFactory.CreateJsonWriter(fs, System.Text.Encoding.UTF8, true, true, "   "))
                            {
                                serializer.WriteObject(writer, Bots.ToArray());
                            }
                        }
                    }
                    catch
                    {
                        // throw;
                        // System.Windows.MessageBox.Show(e.ToString());
                    }
                }
            });

        }
    }
}
