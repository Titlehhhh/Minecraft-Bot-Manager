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
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace MinecraftBotManager.Services
{
    public class ModulesService : IModulesService
    {
        public ObservableCollection<ChatCommand> Commands => new ObservableCollection<ChatCommand>
        {

        };

        public ObservableCollection<Type> AllModules { get; private set; } = new ObservableCollection<Type>();

        public ObservableCollection<ReferencePath> Dlls { get; private set; } = new ObservableCollection<ReferencePath>();
        private readonly IDataService dataService;

        private readonly DirectoryInfo Modules;
        public ModulesService(IDataService dataService)
        {

            this.dataService = dataService;
            AppDomain.CurrentDomain.AssemblyResolve += (a, args) =>
            {
                return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(k => string.Equals(k.GetName().FullName, args.Name));
            };

            Dlls.CollectionChanged += Dlls_CollectionChanged;


            Modules = new DirectoryInfo("Modules");
            if (!Modules.Exists)
                Modules.Create();

            using (FileStream fs = new FileStream(@"Data\MinecraftLibrary.dll",FileMode.OpenOrCreate))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(fs, typeof(BotObject).Assembly);
            }

            Modules.GetFiles("*.dll").ToList().ForEach(x =>
            {
                ReferencePath re = new ReferencePath(x);
                AddDll(re);
            });


            FileSystemWatcher ModulesWatcher = new FileSystemWatcher(Modules.FullName, "*.dll");
            ModulesWatcher.EnableRaisingEvents = true;

            ModulesWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;
            ModulesWatcher.Created += ModulesWatcher_Created;
            ModulesWatcher.Changed += ModulesWatcher_Changed;
            ModulesWatcher.Deleted += ModulesWatcher_Deleted;
        }

        private void AddDll(ReferencePath newDll)
        {
            if (newDll.Modules.Count > 0)
            {
                App.Current.Dispatcher.Invoke(() => { Dlls.Add(newDll); LoadModuleChanged?.Invoke(this, newDll); });
            }

        }
        private void UpdateDll(ReferencePath dll)
        {
            if (dll.Assembly != null)
            {
                TypeNameEquals nameEquals = new TypeNameEquals();

                var context = AllModules.Where(x => x.Assembly.GetName().Name == dll.Assembly.GetName().Name);
                Debug.WriteLine("1" + string.Join(",", context.Select(x => x.Name)));

                var updates = dll.Modules.Where(x => context.Contains(x, nameEquals));

                Debug.WriteLine("2" + string.Join(",", updates.Select(x => x.Name)));

                var old = context.SkipWhile(x=>dll.Modules.Contains(x,nameEquals));
                

                Debug.WriteLine("3" + string.Join(",", old.Select(x => x.Name)));

                var newItems = dll.Modules.Except(old.Concat(updates), nameEquals);

                Debug.WriteLine("4" + string.Join(",", newItems.Select(x => x.Name)));
                foreach (var item in newItems.ToArray())
                {
                    App.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        AllModules.Add(item);
                    }));

                }
                foreach (var item in old.ToArray())
                {

                    App.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        AllModules.Remove(item);

                    }));
                }
                foreach (var item in updates.ToArray())
                {
                    var oldI = AllModules.FirstOrDefault(x => x.Name == item.Name);
                    Debug.WriteLine("OldI" + oldI?.Name);
                    if (oldI != null)
                    {
                        App.Current.Dispatcher.Invoke(new Action(() =>
                        {
                            AllModules.Remove(oldI);
                            AllModules.Add(item);
                        }));
                    }
                }


                foreach (var bot in dataService.GetAllBots().ToArray())
                {
                    foreach (var mod in bot.Modules.ToArray())
                    {
                        if (old.Contains(mod.GetType(), nameEquals))
                        {
                            bot.RemoveType(mod.GetType());
                        }
                        Type newT = dll.Modules.FirstOrDefault(x => x.Name == mod.GetType().Name);

                        if (newT != null)
                        {
                            App.Current.Dispatcher.Invoke(() =>
                            {
                                bot.RemoveType(mod.GetType());
                                bot.AddModule(newT);
                            });
                        }
                        else
                        {
                            Debug.WriteLine("Не найдено!");
                        }
                    }
                }
            }

        }
        private void RemoveDll(ReferencePath old)
        {
            if (old != null)
            {
                foreach (var bot in dataService.GetAllBots())
                {
                    foreach (var mod in bot.Modules)
                    {
                        if (old.Modules.Contains(mod.GetType()))
                        {
                            App.Current.Dispatcher.BeginInvoke(new Action(() =>
                            {
                                bot.RemoveType(mod.GetType());
                            }));

                            //AssemblyLoadContext
                        }
                    }
                }

                App.Current.Dispatcher.Invoke(() =>
                {
                    Dlls.Remove(old);
                    UnLoadModuleChanged?.Invoke(this, old);
                });

            }
        }

        private void Dlls_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            if (e.NewItems != null)
                foreach (ReferencePath newItem in e.NewItems)
                {
                    foreach (var module in newItem.Modules)
                    {
                        AllModules.Add(module);
                    }
                    LoadModuleChanged?.Invoke(this, newItem);
                }
            if (e.OldItems != null)
                foreach (ReferencePath oldItem in e.OldItems)
                {
                    foreach (var module in oldItem.Modules)
                    {
                        App.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            AllModules.Remove(module);
                        }));

                    }
                    App.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        UnLoadModuleChanged?.Invoke(this, oldItem);
                    }));

                }
        }

        private void ModulesWatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            //System.Windows.MessageBox.Show("File delete: " + e.FullPath);
            foreach (var dll in Dlls.ToArray())
            {
                if (dll.Info.FullName == e.FullPath)
                {
                    RemoveDll(dll);
                }
            }


        }

        private void ModulesWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            
            FileSystemWatcher obj = sender as FileSystemWatcher;
            try
            {
                obj.EnableRaisingEvents = false;
                // System.Windows.MessageBox.Show("File Changed: " + e.FullPath);
                try
                {
                    Process.Start(e.FullPath).WaitForExit();
                }
                catch (System.ComponentModel.Win32Exception ex)
                {

                }
                foreach (var dll in Dlls.ToArray())
                {
                    if (dll.Info.FullName == e.FullPath)
                    {
                        UpdateDll(new ReferencePath(new FileInfo(e.FullPath)));
                    }
                }
            }
            finally
            {
                obj.EnableRaisingEvents = true;
            }
        }

        private void ModulesWatcher_Created(object sender, FileSystemEventArgs e)
        {
            //System.Windows.MessageBox.Show("File Created: " + e.FullPath);
            FileInfo info = new FileInfo(e.FullPath);
            var newElement = new ReferencePath(info);
            AddDll(newElement);

        }


        public event LoadModule LoadModuleChanged;
        public event UnLoadModule UnLoadModuleChanged;
    }
    public class TestCommand : ChatCommand
    {
        public override string Name => "TestCommand";
    }
    public class TypeNameEquals : IEqualityComparer<Type>
    {
        public bool Equals(Type x, Type y)
        {
            return x.Name == y.Name;
        }

        public int GetHashCode(Type obj)
        {
            return obj.GetHashCode();
        }
    }
}
