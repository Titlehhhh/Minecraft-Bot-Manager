using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;

namespace MinecraftBotManager.CustomControls.FileProvider
{
    
    public interface ItemBase
    {
        ItemBase ParentNode { get; set; }
        PackIconKind Icon { get; set; }
        bool IsExpanded { get; set; }

        string Name { get; set; }
        ObservableCollection<ItemBase> Items { get; }
    }
    public interface IItem<out TModel> : ItemBase where TModel : FileSystemInfo
    {
        TModel Info { get; }

        string InternalPath { get; set; }
        string FullPath { get; set; }

    }

    [Serializable]
    public abstract class Item<TModel> : INotifyPropertyChanged, IItem<TModel> where TModel : FileSystemInfo
    {
        private RelayCommand<string> exp;

        public virtual RelayCommand<string> OpenExplorerCommand
        {
            get => exp ?? (exp = new RelayCommand<string>(p =>
            {
                try
                {
                    Process.Start("explorer.exe", p);
                }
                catch
                {

                }
            }));
        }


        public ItemBase ParentNode
        {
            get;
            set;
        }
        public virtual ICommand RenameCommand { get; }

        public virtual SolutionItem RootSolution { get; protected set; }

        public virtual TModel Info { get; set; }


        private ObservableCollection<ItemBase> items;

        public ObservableCollection<ItemBase> Items
        {
            get { return items; }
            set
            {
                items = value;
                RaisePropertyChanged();
            }
        }

        private bool editmode = false;

        public bool IsInEditMode
        {
            get { return editmode; }
            set
            {
                editmode = value;
                RaisePropertyChanged();
            }
        }


        private string name;

        public virtual string Name
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged();
            }
        }


        protected void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;



        public virtual string FullPath { get; set; }

        private string internalpath;

        public Item()
        {

        }
        public Item(Item<DirectoryInfo> parent)
        {
            ParentNode = parent;
        }

        public string InternalPath
        {
            get { return internalpath; }
            set
            {
                internalpath = value;
                RaisePropertyChanged();
            }
        }

        private PackIconKind icon;
        public virtual PackIconKind Icon
        {
            get => icon;
            set
            {
                icon = value;
                RaisePropertyChanged();
            }
        }
        private bool isexp;

        public bool IsExpanded
        {
            get { return isexp; }
            set
            {
                isexp = value;
                RaisePropertyChanged();
            }
        }

    }
    public enum ItemType
    {
        Root = 0,
        Directory = 1,
        File = 2
    }
}
