using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.UI.Xaml.Media.Imaging;

namespace MinecraftBotManager.Data
{
    [DataContract]
    public sealed class BotInfo : IDeserializationCallback
    {


        [IgnoreDataMember]
        public Guid Id { get; private set; } = Guid.NewGuid();

        

        [DataMember]
        public string Username { get; set; } 
        [DataMember]
        public string Server { get; set; } 
        [DataMember]
        public int ProtocolVersion { get; set; }
        [DataMember]
        public bool AuthEnabled { get; set; }
        

        [DataMember]
        public AccountType AccType { get; set; }

        public string Password { get; set; } 
        [DataMember]
        public bool ProxyEnabled { get; set; } 
        [DataMember]
        public bool OptimaleProxy { get; set; } 
        [DataMember]
        public string ProxyAddress { get; set; }
        [DataMember]
        public TypeProxy ProxyType { get; set; } 
        [DataMember]
        public string ProxyLogin { get; set; } 
        [DataMember]
        public string ProxyPass { get; set; } 

       // [DataMember]
       // public List<string> Plugins { get; set; } = new();

        private void Inizialize()
        {
            
        }

        public void OnDeserialization(object sender)
        {
            Id = Guid.NewGuid();
            

        }
    }
}
