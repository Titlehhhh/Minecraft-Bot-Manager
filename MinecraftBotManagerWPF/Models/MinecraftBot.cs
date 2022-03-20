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
    public class MinecraftBot : IMinecraftBot
    {
        public IProtocolClient ProtocolClient { get; private set; }
        
        [DataMember(Name ="nick")]
        public string Nickname { get; set; }
        [DataMember(Name = "host")]
        public string Host { get; set; }
        [DataMember(Name = "port")]
        public ushort Port { get; set; }
        [DataMember(Name = "IsAuth")]
        public bool IsAuth { get; set; }
        [DataMember(Name = "IsProxy")]
        public bool IsProxy { get; set; }
        
        public ProxyInfo? Proxy { get; set; }
       
        public AuthInfo? Auth { get; set; }

        public MinecraftBot()
        {

        }

        public void StartBot()
        {

            this.ProtocolClient = new ProtocolClient();
            this.ProtocolClient.Nickname = this.Nickname;
            this.ProtocolClient.Host = this.Host;

            this.ProtocolClient.Connected += () => { };
            this.ProtocolClient.Disconnected += (s,e) => { };
            this.ProtocolClient.LoginSucces += (s, e) => { };
            


            this.ProtocolClient.Connect();
            
            

        }
        public void StopBot()
        {

        }

        public void Dispose()
        {
            ProtocolClient.Dispose();
        }


    }

   
}
