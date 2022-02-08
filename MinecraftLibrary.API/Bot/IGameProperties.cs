using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MinecraftLibrary.Geometry;
using MinecraftLibrary.NBT.Tags;

namespace MinecraftLibrary.API.Bot
{

    public interface IGameProperties
    {
        public float Health { get; }
        public float Saturation { get; }
        public Point3 Position { get; }
        public float Yaw { get; }
        public float Pitch { get; }
        public GAMEMODE Gamemode { get; }
        public Guid UUID { get; }
        public bool IsHardcore { get; }
        public int EntityID { get; } 
    }
    



}
