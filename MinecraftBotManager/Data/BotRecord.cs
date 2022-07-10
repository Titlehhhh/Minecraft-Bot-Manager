using Starksoft.Net.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.UI.Xaml.Media.Imaging;

namespace MinecraftBotManager.Data
{
    [DataContract]
    public class BotRecord : IDeserializationCallback
    {


        [IgnoreDataMember]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [IgnoreDataMember]
        public BitmapImage Icon { get; set; } = new();

        [DataMember]
        public string Username { get; set; } 
        [DataMember]
        public string Server { get; set; } 
        [DataMember]
        public string Version { get; set; }
        [DataMember]
        public bool AuthEnabled { get; set; }
        [DataMember]
        public string Password { get; set; } 
        [DataMember]
        public bool ProxyEnabled { get; set; } 
        [DataMember]
        public bool OptimaleProxy { get; set; } 
        [DataMember]
        public string ProxyAddress { get; set; }
        [DataMember]
        public ProxyType ProxyType { get; set; } 
        [DataMember]
        public string ProxyLogin { get; set; } 
        [DataMember]
        public string ProxyPass { get; set; } 

        [DataMember]
        public List<string> Plugins { get; set; } = new();

        private void Inizialize()
        {
            
        }

        public void OnDeserialization(object sender)
        {
            Id = Guid.NewGuid();
            Icon = new();
        }
    }
}
