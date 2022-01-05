using MinecraftBotManager.Interfaces;
using MinecraftBotManager.Models;
using MinecraftBotManager.ViewModel;
using MinecraftLibrary.MinecraftModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Services
{
    public class DataService : IDataService
    {
        private List<BotObject> botObjects;
        private IStorageService storageService;
        private IXMLSerializeSettingsService xmlService;

        public DataService(IStorageService storageService, IXMLSerializeSettingsService xmlService)
        {
            this.storageService = storageService;
            this.xmlService = xmlService;
            Config = xmlService.LoadSettings();
            if (!Directory.Exists("Data"))
                Directory.CreateDirectory("Data");

            BotsCollectionChanged += DataService_CollectionChanged;
            LoadData();            
        }

        private void DataService_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            storageService.SaveObjectAsync(botObjects, "Data/Bots.dat");
        }

        private void LoadData()
        {
            botObjects = (List<BotObject>) storageService.LoadObjectAsync("Data/Bots.dat").Result ?? new List<BotObject>();
            botObjects.ForEach((item) => { item.PropertyChanged += Item_PropertyChanged; });
        }

        private void Item_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            
        }

        public event NotifyCollectionChangedEventHandler BotsCollectionChanged;
        public event NotifyCollectionChangedEventHandler ProxyServersCollectionChanged;
        public event NotifyCollectionChangedEventHandler DocumentsCollectionChanged;

        public void AddBot(BotObject newBot)
        {
            botObjects.Add(newBot);
            newBot.PropertyChanged += Item_PropertyChanged;
            BotsCollectionChanged?.Invoke(this,new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add,new List<BotObject> { newBot}));
        }

        public IEnumerable<BotObject> GetAllBots()
        {
            return botObjects;
        }

        public IEnumerable<ProxyServer> GetProxyServers()
        {
            return null;
        }

        public void RemoveBot(BotObject remove)
        {
            remove.PropertyChanged -= Item_PropertyChanged;
            botObjects.Remove(remove);
            BotsCollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, new List<BotObject> { remove }));
        }


        public void AddProxy(ProxyServer newProxy)
        {
            throw new NotImplementedException();
        }

        public void RemoveProxy(ProxyServer remove)
        {
            throw new NotImplementedException();
        }
        

        public ConfigModel Config { get; private set; }

       


        public void Save()
        {
            try
            {
                storageService.SaveObjectAsync(botObjects, "Data/Bots.dat");
                xmlService.SaveSettings();
            }
            catch(Exception e)
            {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }
    }
}
