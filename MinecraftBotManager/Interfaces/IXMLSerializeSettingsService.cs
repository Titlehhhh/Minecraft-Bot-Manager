using MinecraftBotManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Interfaces
{
    public interface IXMLSerializeSettingsService
    {
        ConfigModel LoadSettings();
        void SaveSettings();
    }
}
