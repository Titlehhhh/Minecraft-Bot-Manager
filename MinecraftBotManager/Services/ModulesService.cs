using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinecraftBotManager.Interfaces;
using MinecraftBotManager.Models;
using MinecraftLibrary.MinecraftModels;

namespace MinecraftBotManager.Services
{
    public class ModulesService : IModulesService
    {
        public ObservableCollection<ChatCommand> Commands => new ObservableCollection<ChatCommand>
        {
            new TestCommand(),
            new TestCommand(),
            new TestCommand()
        };

        public ObservableCollection<Type> AllModules { get; private set; } = new ObservableCollection<Type>();

        public ObservableCollection<ReferencePath> Dlls { get; private set; } = new ObservableCollection<ReferencePath>();

        public ModulesService()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (a,args) =>
            {                
                return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(k => string.Equals(k.GetName().FullName, args.Name));
            };

            Dlls.CollectionChanged += Dlls_CollectionChanged;
            DirectoryInfo Modules = new DirectoryInfo("Modules");
            if (!Modules.Exists)
                Modules.Create();

            Modules.GetFiles("*.dll").ToList().ForEach(x =>
            {
                ReferencePath re = new ReferencePath(x);
                if (re.Modules.Count > 0)
                {
                    Dlls.Add(re);
                    re.Modules.ForEach(m => AllModules.Add(m));
                }
            });


            FileSystemWatcher ModulesWatcher = new FileSystemWatcher(Modules.FullName, "*.dll");
            ModulesWatcher.EnableRaisingEvents = true;
            ModulesWatcher.NotifyFilter = NotifyFilters.FileName;
            ModulesWatcher.Created += ModulesWatcher_Created;
            ModulesWatcher.Changed += ModulesWatcher_Changed;
            ModulesWatcher.Deleted += ModulesWatcher_Deleted;
        }


        private void Dlls_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
                foreach (ReferencePath newItem in e.NewItems)
                    LoadModuleChanged?.Invoke(this, newItem);
            if (e.OldItems != null)
                foreach (ReferencePath oldItem in e.OldItems)
                    UnLoadModuleChanged?.Invoke(this, oldItem);
        }

        private void ModulesWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            ReferencePath old = Dlls.FirstOrDefault(x => x.Info.FullName == e.FullPath);
            if (old != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    Dlls.Remove(old);
                });
            }
        }

        private void ModulesWatcher_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void ModulesWatcher_Created(object sender, FileSystemEventArgs e)
        {
            var newElement = new ReferencePath(new FileInfo(e.FullPath));
            if (newElement.Modules.Count > 0)
                App.Current.Dispatcher.Invoke(() => Dlls.Add(newElement));

        }


        public event LoadModule LoadModuleChanged;
        public event UnLoadModule UnLoadModuleChanged;
    }
    public class TestCommand : ChatCommand
    {
        public override string Name => "TestCommand";
    }
}
