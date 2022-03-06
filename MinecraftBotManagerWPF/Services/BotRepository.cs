using MinecraftBotManagerWPF.Interfaces;
using MinecraftBotManagerWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MinecraftBotManagerWPF.Services
{
    public class BotRepository : IBotRepository
    {
        public event AddBotHandler? AddBotEvent;

        private readonly List<Bot> Bots;

        public BotRepository()
        {
            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                string path = @"Database\bots.data";
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    this.Bots = (List<Bot>)bin.Deserialize(fs);
                }
            }
            catch (Exception e)
            {
                throw;
                System.Windows.MessageBox.Show(e.ToString());
                this.Bots = new List<Bot>();
            }
        }

        public void AddBot(Bot bot)
        {
            Bots.Add(bot);
            AddBotEvent?.Invoke(bot);
            Save();
        }

        public IEnumerable<Bot> GetAllBots()
        {
            return new List<Bot>(this.Bots);
        }

        public void RemoveBot(Bot bot)
        {
            this.Bots.Remove(bot);
            Save();
        }

        public void Save()
        {
            try
            {
                BinaryFormatter bin = new BinaryFormatter();
                string path = @"Database\bots.data";
                Directory.CreateDirectory(Path.GetDirectoryName(path));
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    bin.Serialize(fs, this.Bots);
                }
            }
            catch (Exception e)
            {
                throw;
               // System.Windows.MessageBox.Show(e.ToString());
            }

        }
    }
    public class DataService : IDataService
    {
        private readonly IBotRepository botRepository = new BotRepository();

        public DataService()
        {

        }
        public IBotRepository BotRepository => botRepository;
    }
}
