using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.PluginAPI;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    [DataContract]
    public class BotInfo
    {
        [DataMember]
        public string Nickname { get; set; }
        [DataMember]
        public bool IsAuth { get; set; }
        [DataMember]
        public AuthInfo? Auth { get; set; }
        [DataMember]
        public string Host { get; set; }

        [DataMember]
        public bool IsProxy { get; set; }
        [DataMember]
        public ProxyInfo? Proxy { get; set; }


    }
}
