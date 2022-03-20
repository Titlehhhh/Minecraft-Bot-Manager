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
        private static readonly DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BotInfo[]), settings);
        private static readonly DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings()
        {
            RootName = "Bots",
            UseSimpleDictionaryFormat = true,
        };

        public event AddBotHandler? AddBotEvent;

        private readonly List<BotInfo> Bots;

        public BotRepository()
        {
            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                string path = @"Database\bots.json";
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (FileStream fs = File.OpenRead(path))
                {
                    Bots = new List<BotInfo>(serializer.ReadObject(fs) as IEnumerable<BotInfo>);
                }
            }
            catch (Exception e)
            {
                //System.Windows.MessageBox.Show(e.ToString());
                this.Bots = new List<BotInfo>();
            }
        }

        public async Task AddBot(BotInfo bot)
        {
            Bots.Add(bot);
            AddBotEvent?.Invoke(bot);
            await Save();
        }

        public IEnumerable<BotInfo> GetAllBots()
        {
            return new List<BotInfo>(this.Bots);
        }

        public async Task RemoveBot(BotInfo bot)
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
