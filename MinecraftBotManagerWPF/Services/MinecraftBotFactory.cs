using MinecraftLibrary.PluginAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public sealed class MinecraftBotFactory
    {
        public MinecraftBot CreateBot(BotInfo info)
        {
            ushort port = 25565;
            string host = "";
            var hostport = info.Host?.Split(':');
            if (hostport.Length == 2)
            {
                host = hostport[0];
                try
                {
                    port = ushort.Parse(hostport[1]);
                }
                catch { }
            }

            return new MinecraftBot()
            {
                Nickname = info.Nickname,
                Host = host,
                Port = port,
                IsProxy = false,
                IsAuth = false,
                Proxy = null,
                Auth = null

            };
        }
    }
}
