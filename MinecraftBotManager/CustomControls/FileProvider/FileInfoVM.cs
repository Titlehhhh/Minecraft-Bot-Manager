using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MinecraftBotManager.CustomControls.FileProvider
{
    public class FileInfoVM : Item<FileInfo>
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
                    string newFull = (ParentNode as Item<DirectoryInfo>).FullPath + @"\" + value;
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

        public override FileInfo Info
        {
            get => base.Info;
            set
            {
                base.Info = value;
                FullPath = value.FullName;
                Name = value.FullName.Replace(value.Directory.FullName + @"\", "");
                InternalPath = value.Name;
            }
        }

        private string ext;

        public string Extension
        {
            get { return ext; }
            private set
            {
                ext = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(Icon));
            }
        }


        private RelayCommand<object> openwin;

        public RelayCommand<object> OpenWinCommand
        {
            get => openwin ?? (openwin = new RelayCommand<object>(p =>
            {
                try
                {
                    ProcessStartInfo info = new ProcessStartInfo(FullPath);
                    info.CreateNoWindow = true;
                    

                    Process process = new Process();
                    process.StartInfo = info;
                    process.Start();
                    
                }
                catch
                {

                }
            }));
        }





        public FileInfoVM(FileInfo fileInfo, SolutionItem solution, Item<DirectoryInfo> parent) : base(parent)
        {
            Items = new System.Collections.ObjectModel.ObservableCollection<ItemBase>();
            RootSolution = solution;

            Info = fileInfo;
            InternalPath = FullPath.Replace(solution.FullPath + @"\", "");

        }



    }
}
