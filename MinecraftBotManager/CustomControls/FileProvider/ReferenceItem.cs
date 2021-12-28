using System;
using System.IO;
using System.Xml.Serialization;

namespace MinecraftBotManager.CustomControls.FileProvider
{
    
    public class ReferenceItem :Item<FileInfo>
    {
        
        public override string FullPath { get => base.FullPath; set => base.FullPath = value; }
        public ReferenceItem(FileInfo info) : base()
        {
            Info = info;
            Name = Path.GetFileNameWithoutExtension(Info.FullName);
        }
        public ReferenceItem()
        {

        }
        public override string ToString()
        { 
            return Name;
        }
    }
}
