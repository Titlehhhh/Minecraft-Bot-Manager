using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MinecraftBotManager.CustomControls.FileProvider
{
    public class DirectoryInfoVM : Item<DirectoryInfo>
    {
        



        private ICommand rename;
        public override ICommand RenameCommand
        {
            get => rename ?? (rename = new RelayCommand<object>(p =>
            {
                IsInEditMode = true;
            }));
        }

        public override string Name
        {
            get { return Info.Name; }
            set
            {

                if (!string.IsNullOrEmpty(value))
                {
                    string newFull = (ParentNode as Item<DirectoryInfo>)?.FullPath + @"\" + value;
                    if (!string.IsNullOrEmpty(newFull))
                    {
                        try
                        {
                            Info.MoveTo(newFull);
                        }
                        catch (Exception e)
                        {

                        }
                    }
                }
                RaisePropertyChanged();
                IsInEditMode = false;
            }
        }       
        public override DirectoryInfo Info
        {
            get => base.Info;
            set
            {
                base.Info = value;
                FullPath = value.FullName;
                Name = value.Name;
                InternalPath = FullPath.Replace(RootSolution.FullPath + @"\", "");
            }
        }

        public DirectoryInfoVM(DirectoryInfo directoryInfo, SolutionItem solution, Item<DirectoryInfo> parent, bool isFind = true) : base(parent)
        {            
            RootSolution = solution;
            Info = directoryInfo;
            Items = new ObservableCollection<ItemBase>();            
            if (isFind)
            {
                List<IItem<FileSystemInfo>> items = SolutionItem.ScanDirectory(FullPath, this,solution);
                foreach (IItem<FileSystemInfo> item in items)
                    Items.Add(item);
            }
            
            
        }

    }
}
