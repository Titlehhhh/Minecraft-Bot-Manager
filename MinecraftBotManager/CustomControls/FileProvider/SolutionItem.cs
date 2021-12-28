using GalaSoft.MvvmLight.Messaging;
using MaterialDesignThemes.Wpf;
using MinecraftBotManager.ViewModel;
using MinecraftBotManager.Views.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.CustomControls.FileProvider
{
    public delegate void FileDeleteHandler(object sender, FileInfoVM fileInfo);
    public delegate void FileCreateHandler(object sender, FileInfoVM newElement);
    public delegate void DirectoryCreateHandler(object sender, DirectoryInfoVM newFolder);
    public delegate void DirectoryDeleteHandler(object sender, DirectoryInfoVM oldFolder);
    public abstract class SolutionItem : Item<DirectoryInfo>
    {
        private HashSet<string> BlackList = new HashSet<string>();
        public override SolutionItem RootSolution => this;

        public event FileDeleteHandler FileDeleteChanged;
        public event FileCreateHandler FileCreateChanged;
        public event DirectoryCreateHandler DirectoryCreateChanged;
        public event DirectoryDeleteHandler DirectoryDeleteChanged;


        private readonly FileSystemWatcher filewatcher = new FileSystemWatcher();
        private readonly FileSystemWatcher dirwatcher = new FileSystemWatcher();
        public FileSystemWatcher FileWatcher => filewatcher;
        public FileSystemWatcher DirectoryWatcher => dirwatcher;
        public Dictionary<string, CompileAction> MetadataFiles { get; private set; } = new Dictionary<string, CompileAction>();

        public virtual void Compile(ObservableCollection<string> Console)
        {

        }

        public SolutionItem(string path,bool scanning = true)
        {
          


            FullPath = path;
            Items = new ObservableCollection<ItemBase>();

            if (scanning)
            {
                List<IItem<FileSystemInfo>> newItems = ScanDirectory(FullPath, this, this);
                foreach (IItem<FileSystemInfo> item in newItems)
                    Items.Add(item);
            }

            filewatcher.Path = FullPath;
            filewatcher.IncludeSubdirectories = true;            
            filewatcher.NotifyFilter = NotifyFilters.FileName;
            filewatcher.EnableRaisingEvents = true;
            filewatcher.Created += Filewatcher_Created;
            filewatcher.Deleted += Filewatcher_Deleted;
            filewatcher.Renamed += Filewatcher_Renamed;

            dirwatcher.Path = FullPath;
            dirwatcher.IncludeSubdirectories = true;
            dirwatcher.NotifyFilter = NotifyFilters.DirectoryName;
            dirwatcher.EnableRaisingEvents = true;
            dirwatcher.Created += Dirwatcher_Created;
            dirwatcher.Deleted += Dirwatcher_Deleted;
            dirwatcher.Renamed += Dirwatcher_Renamed;

        }



        private void Load()
        {

        }
        #region Команды
        private RelayCommand<object> addelement;

        public RelayCommand<object> AddNewElementCommand
        {
            get => addelement ?? (addelement = new RelayCommand<object>(p =>
            {
                Messenger.Default.Send<NotificationMessageAction>(new NotificationMessageAction("",()=> { }),ModuleMenegerWindow.Token);
            }));
        }
        private RelayCommand<Item<DirectoryInfo>> addfolder;

        public virtual RelayCommand<Item<DirectoryInfo>> AddFolderCommand
        {
            get => addfolder ?? (addfolder = new RelayCommand<Item<DirectoryInfo>>(p =>
            {
                int id = 1;
                string name = "NewFolder";               
                while (Directory.Exists(Path.Combine(p.FullPath, name+ id.ToString())))
                    id++;
                var deb = Path.Combine(p.FullPath, name + id.ToString());
                DirectoryInfo directoryInfo = new DirectoryInfo(deb);
                BlackList.Add(directoryInfo.FullName);
                directoryInfo.Create();
                DirectoryInfoVM newFolder = new DirectoryInfoVM(directoryInfo, this, p);                
                p.Items.Add(newFolder);
                p.IsExpanded = true;
                newFolder.IsInEditMode = true;
            }));
        }


        private RelayCommand<ItemBase> delete;

        public virtual RelayCommand<ItemBase> DeleteCommand
        {
            get => delete ?? (delete = new RelayCommand<ItemBase>(async p =>
            {
                bool result = (bool)await DialogHost.Show(new ConfirmDialogVM("Вы точно хотите удалить?"), ModuleMenegerViewModel.DialogID);
                if (result)
                {
                    if (p is DirectoryInfoVM)
                    {
                        RemoveDirectory(p as DirectoryInfoVM);
                    }
                    else if (p is FileInfoVM)
                    {
                        RemoveFile(p as FileInfoVM);
                    }
                }
            }));
        }



        #endregion

        private void RemoveDirectory(DirectoryInfoVM directory)
        {
            if (directory != null)
            {
                BlackList.Add(directory.FullPath);

                directory.Info.Delete(true);
                directory.ParentNode.Items.Remove(directory);
                Enumerate(directory).ToList().ForEach(f => FileDeleteChanged?.Invoke(this, f));
            }
        }
        private void RemoveFile(FileInfoVM file)
        {
            if (file != null)
            {
                BlackList.Add(file.FullPath);
                file.Info.Delete();
                file.ParentNode.Items.Remove(file);
                FileDeleteChanged?.Invoke(this, file);
            }
        }


        public static List<IItem<FileSystemInfo>> ScanDirectory(string directory, Item<DirectoryInfo> parent, SolutionItem solution)
        {
            try
            {
                List<IItem<FileSystemInfo>> result = new List<IItem<FileSystemInfo>>();
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                foreach (var dir in directoryInfo.GetDirectories())
                {
                    var item = new DirectoryInfoVM(dir, solution, parent);
                    result.Add(item);
                }
                foreach (var file in directoryInfo.GetFiles())
                {
                    var item = new FileInfoVM(file, solution, parent);
                    result.Add(item);
                }

                return result;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return new List<IItem<FileSystemInfo>>();
            }
        }
        #region Watcher


        #region DirWatcher

        protected virtual void Dirwatcher_Renamed(object sender, RenamedEventArgs e)
        {
            DirectoryInfoVM old = FindItemInternal(e.OldName) as DirectoryInfoVM;
            if (old != null)
            {
                App.Current.Dispatcher.Invoke(() => { old.Info = new DirectoryInfo(e.FullPath); });
            }
        }

        protected virtual void Dirwatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            string internalPath = Path.GetDirectoryName(e.Name);
            IItem<FileSystemInfo> container = FindItemInternal(internalPath);
            if (container != null)
            {
                DirectoryInfoVM old = container.Items.OfType<IItem<DirectoryInfo>>().FirstOrDefault(i => i.InternalPath == e.Name) as DirectoryInfoVM;
                if (old != null)
                {
                    if (BlackList.Contains(old.FullPath))
                    {
                        BlackList.Remove(old.FullPath);
                    }
                    else
                    {
                        App.Current.Dispatcher.Invoke(() => container.Items.Remove(old));
                        DirectoryDeleteChanged?.Invoke(this, old);
                        Enumerate(old).ToList().ForEach(f => FileDeleteChanged?.Invoke(this, f));
                    }
                }
            }
        }

        protected virtual void Dirwatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (BlackList.Contains(e.FullPath))
            {
                BlackList.Remove(e.FullPath);
            }
            else
            {
                string internalPath = Path.GetDirectoryName(e.Name);
                Item<DirectoryInfo> container = FindItemInternal(internalPath) as Item<DirectoryInfo>;
                if (container != null)
                {
                    DirectoryInfoVM newElement = new DirectoryInfoVM(new DirectoryInfo(e.FullPath), this, container);
                    App.Current.Dispatcher.Invoke(() => container.Items.Add(newElement));
                    DirectoryCreateChanged?.Invoke(this, newElement);
                    Enumerate(newElement).ToList().ForEach(f => FileCreateChanged?.Invoke(this, f));
                }
            }
        }
        #endregion
        #region FileWatcher

        protected virtual void Filewatcher_Renamed(object sender, RenamedEventArgs e)
        {
            FileInfoVM replaced = FindItemInternal(e.OldName) as FileInfoVM;
            if (replaced != null)
            {
                App.Current.Dispatcher.Invoke(() => { replaced.Info = new FileInfo(e.FullPath); });
            }
        }

        protected virtual void Filewatcher_Deleted(object sender, FileSystemEventArgs e)
        {
            if (BlackList.Contains(e.FullPath))
            {
                BlackList.Remove(e.FullPath);
            }
            else
            {
                string internalPath = Path.GetDirectoryName(e.Name);
                IItem<FileSystemInfo> container = FindItemInternal(internalPath);
                if (container != null)
                {
                    FileInfoVM old = container.Items.OfType<IItem<FileInfo>>().FirstOrDefault(i => i.InternalPath == e.Name) as FileInfoVM;
                    if (old != null)
                    {
                        App.Current.Dispatcher.Invoke(() => container.Items.Remove(old));
                        FileDeleteChanged?.Invoke(this, old);
                    }
                }
            }
        }

        protected virtual void Filewatcher_Created(object sender, FileSystemEventArgs e)
        {
            if (BlackList.Contains(e.FullPath))
            {
                BlackList.Remove(e.FullPath);
            }
            else
            {
                string internalPath = Path.GetDirectoryName(e.Name);
                Item<DirectoryInfo> container = FindItemInternal(internalPath) as Item<DirectoryInfo>;
                if (container != null)
                {
                    FileInfoVM newElement = new FileInfoVM(new FileInfo(e.FullPath), this, container);
                    App.Current.Dispatcher.Invoke(() => container.Items.Add(newElement));
                    FileCreateChanged?.Invoke(this, newElement);
                }
            }
        }
        #endregion
        #endregion
        private IEnumerable<FileInfoVM> Enumerate(DirectoryInfoVM directoryInfo)
        {
            List<FileInfoVM> result = new List<FileInfoVM>();
            result.AddRange(directoryInfo.Items.OfType<FileInfoVM>() ?? new List<FileInfoVM>());
            foreach (DirectoryInfoVM item in directoryInfo.Items.OfType<DirectoryInfoVM>())
                result.AddRange(Enumerate(item));
            return result;
        }


        public IItem<FileSystemInfo> FindItemInternal(string internalpath)
        {
            if (internalpath == "")
                return this;
            return FindRecursive(Items.OfType<IItem<FileSystemInfo>>().Where(x => x.GetType() == typeof(FileInfoVM) || x.GetType() == typeof(DirectoryInfoVM)), internalpath);
        }
        private static IItem<FileSystemInfo> FindRecursive(IEnumerable<IItem<FileSystemInfo>> items, string path)
        {
            if (items != null)
                foreach (IItem<FileSystemInfo> item in items)
                {
                    if (item.InternalPath == path)
                    {
                        return item;
                    }
                    else
                    {
                        IItem<FileSystemInfo> finding = FindRecursive(item.Items.OfType<IItem<FileSystemInfo>>(), path); ;
                        if (finding != null)
                        {
                            return finding;
                        }
                    }
                }
            return null;
        }




    }
    public enum CompileAction : byte
    {
        None = 0,
        Compile = 1
    }
}
