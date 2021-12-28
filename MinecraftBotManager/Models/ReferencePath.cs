using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using MinecraftLibrary.MinecraftModels;

namespace MinecraftBotManager.Models
{
    public class ReferencePath
    {
        public FileInfo Info { get; private set; }
        public Assembly Assembly { get; set; }
        public string Name { get; set; }
        public List<Type> Modules { get; private set; } = new List<Type>();
        public ReferencePath(FileInfo fileInfo)
        {
            try
            {
                
                Assembly = Assembly.Load(AssemblyName.GetAssemblyName(fileInfo.FullName));
                AppDomain.CurrentDomain.Load(Assembly.FullName);
                foreach (Type module in Assembly.GetTypes())
                {
                    if (module.IsSubclassOf(typeof(MinecraftModule)))
                    {
                        Modules.Add(module);
                    }
                }
            }
            catch
            {
                Assembly = null;
            }
            Name = Path.GetFileNameWithoutExtension(fileInfo.FullName);
            Info = fileInfo;
        }
        public ReferencePath()
        {

        }

    }
}
