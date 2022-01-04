using MinecraftBotManager.Interfaces;
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

namespace MinecraftBotManager.Services
{
    public class DesignDataService : IDataService
    {
        public ConfigModel Config => throw new NotImplementedException();

        public event NotifyCollectionChangedEventHandler BotsCollectionChanged;
        public event NotifyCollectionChangedEventHandler ProxyServersCollectionChanged;
        public event NotifyCollectionChangedEventHandler DocumentsCollectionChanged;

        public void AddBot(BotObject newBot)
        {

        }

        public void AddDocument(TextDocumentWrap newDocument)
        {
            throw new NotImplementedException();
        }

        public void AddProxy(ProxyServer newProxy)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BotObject> GetAllBots()
        {
            return new List<BotObject>
            {
                new BotObject(){Nickname = "asd"}
            };
        }

        public IEnumerable<TextDocumentWrap> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProxyServer> GetProxyServers()
        {
            throw new NotImplementedException();
        }

        public void RemoveBot(BotObject remove)
        {
            throw new NotImplementedException();
        }

        public void RemoveDocument(TextDocumentWrap old)
        {
            throw new NotImplementedException();
        }

        public void RemoveProxy(ProxyServer remove)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
