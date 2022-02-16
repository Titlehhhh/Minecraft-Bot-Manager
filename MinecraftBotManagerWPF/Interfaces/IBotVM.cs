using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF.Interfaces
{
    public interface IBotVM
    {
        string Username { get; set; }
        string Host { get; set; }
        string Port { get; set; }
        bool ProxyEnabled { get; set; }


    }
}
