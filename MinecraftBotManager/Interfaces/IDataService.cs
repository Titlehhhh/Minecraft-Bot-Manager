using MinecraftBotManager.Models;
using MinecraftBotManager.ViewModel;
using MinecraftLibrary.MinecraftModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Interfaces
{
    
    public interface IDataService
    {
        event NotifyCollectionChangedEventHandler BotsCollectionChanged;
        event NotifyCollectionChangedEventHandler ProxyServersCollectionChanged;
        event NotifyCollectionChangedEventHandler DocumentsCollectionChanged;

        IEnumerable<BotObject> GetAllBots();
        IEnumerable<ProxyServer> GetProxyServers();
       
        void AddBot(BotObject newBot);
        void RemoveBot(BotObject remove);
        void Save();
        void AddProxy(ProxyServer newProxy);
        void RemoveProxy(ProxyServer remove);
        
        
        ConfigModel Config { get; }
    }
}
