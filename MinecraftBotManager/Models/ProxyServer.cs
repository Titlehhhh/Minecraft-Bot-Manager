using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Starksoft.Net.Proxy;

namespace MinecraftBotManager.Models
{
    
    public class ProxyServer
    {
        
        private string proxyhost;

        public string ProxyHost
        {
            get { return proxyhost; }
            set
            {
                proxyhost = value;
               
            }
        }
        private int proxyport;

        public int ProxyPort
        {
            get { return proxyport; }
            set
            {
                proxyport = value;                
            }
        }
        private ProxyType prox;

        public ProxyType Proxy_Type
        {
            get { return prox; }
            set { prox = value; }
        }




    }
}
