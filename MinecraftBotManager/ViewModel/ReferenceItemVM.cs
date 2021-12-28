using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.IO;
using System.Reflection;
using MinecraftBotManager.CustomControls.FileProvider;
using MinecraftLibrary.MinecraftModels;

namespace MinecraftBotManager.ViewModel
{
    public class ReferenceItemVM : ObservableObject
    {
        public ReferenceItem Model { get; private set; }
        public string Name => Model.Name;
        public bool Exists
        {
            get => Model.Info.Exists;            
        }

        public string FullPath => Model.FullPath;
        public Assembly Assembly { get; private set; }

        public List<string> Modules { get; private set; } = new List<string>();

        public ReferenceItemVM(ReferenceItem referenceItem)
        {
            Model = referenceItem;
            Assembly = Assembly.LoadFrom(FullPath);

            foreach(Type t in Assembly.GetTypes())
            {
                if(t.IsClass && t.IsSubclassOf(typeof(MinecraftModule)))
                {
                    Modules.Add(t.Name);
                }
            }
            
        }

    }
}
