using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using System.Linq;
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
            Update(fileInfo);
        }
        public ReferencePath()
        {

        }
        
        public void Unload()
        {
            
        }
        public void Update(FileInfo info)
        {
            try
            {

                Assembly = Assembly.Load(File.ReadAllBytes(info.FullName));

                AppDomain.CurrentDomain.Load(Assembly.FullName);
                foreach (Type module in Assembly.GetTypes())
                {
                    if (module.IsSubclassOf(typeof(MinecraftModule)))
                    {
                        Modules.Add(module);
                    }
                }

            }
            catch(ReflectionTypeLoadException e)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + string.Join("\n", e.LoaderExceptions.Select(x=>x.ToString())));
            }
            catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine("При загрузки dll произошло исключение: \n"+e);
                
            }
            Name = Path.GetFileNameWithoutExtension(info.FullName);
            Info = info;
        }
    }
}
