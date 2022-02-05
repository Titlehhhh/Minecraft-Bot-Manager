using MinecraftLibrary.API.Protocol.Helpres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.NBT.Tags
{
    public abstract class NbtTag
    {
        public string Name { get; set; }
        public NbtTag? Parent { get; }
        public abstract NbtTagType TagType { get; }
        public abstract void Read(MinecraftStream stream);
        public abstract void Write(MinecraftStream stream);
        public NbtTag(NbtTag parent)
        {
            Parent = parent;
        }
        public NbtTag()
        {
            
        }
    }
}
