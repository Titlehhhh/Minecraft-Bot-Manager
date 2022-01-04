using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftBotManager.Interfaces;
using MinecraftBotManager.Models;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace MinecraftBotManager.Services
{
    public class XMLService : IXMLSerializeSettingsService
    {
        private ConfigModel configModel= new ConfigModel();
        public ConfigModel LoadSettings()
        {
            XmlSerializer xml = new XmlSerializer(typeof(ConfigModel));           
            try
            {
                using (FileStream fs = new FileStream(@"DataBase\Settings.xml", FileMode.OpenOrCreate))
                {
                    configModel = xml.Deserialize(fs) as ConfigModel;
                }
            }
            catch
            {

            }
            return configModel;
        }

        public void SaveSettings()
        {
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(ConfigModel));                
                using (TextWriter tw = new StreamWriter("DataBase/Settings.xml"))
                {
                    xml.Serialize(tw, configModel);
                }
            }
            catch { }
        }
    }
}
