using MaterialDesignThemes.Wpf;
using System.Collections.ObjectModel;
using System.IO;

namespace MinecraftBotManager.CustomControls.FileProvider
{
    public class ReferenceContainer : IItem<DirectoryInfo>
    {
        public ReferenceContainer()
        {

        }

        public string Name { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public ObservableCollection<ItemBase> Items => new ObservableCollection<ItemBase>();

        public PackIconKind Icon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public bool IsExpanded { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public DirectoryInfo Info => throw new System.NotImplementedException();

        public string InternalPath { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public string FullPath { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        public ItemBase ParentNode { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    }
}
