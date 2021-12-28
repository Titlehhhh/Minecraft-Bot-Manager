using GalaSoft.MvvmLight;
using MaterialDesignThemes.Wpf;
using MinecraftBotManager.CustomControls.FileProvider;
using MinecraftBotManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.ViewModel
{
    public class ExplorerViewModel : ViewModelBase
    {
        

        private ObservableCollection<SolutionItem> solutions = new ObservableCollection<SolutionItem>();

        public ObservableCollection<SolutionItem> Solutions
        {
            get { return solutions; }
            set
            {
                solutions = value;
                RaisePropertyChanged();
            }
        }
        private RelayCommand<IItem<FileSystemInfo>> additem;

        public RelayCommand<IItem<FileSystemInfo>> CreateElementCommand
        {
            get => additem ?? (additem = new RelayCommand<IItem<FileSystemInfo>>(async p =>
            {
                
            }));
        }

        public ExplorerViewModel(IStorageService storageService)
        {

        }
    }
    public class CreateElementVisitor : ICreateElementVisitor
    {
        public void CreateFile(SolutionItem solutionItem)
        {
            
        }

        public void CreateFile(DirectoryInfoVM directory)
        {
            
        }

        public void CreateFolder(SolutionItem solutionItem)
        {
            
        }

        public void CreateFolder(DirectoryInfoVM directoryItem)
        {
            
        }
    }

}
