using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol
{
    public class PositionRotationEventArgs
    {
        public Point3 Position { get; private set; }
        public float Yaw { get; private set; }
        public float  pitch { get; private set; }
        public bool OnGround { get; private set; }
        public List<PositionElement> Relative { get; private set; }

        public PositionRotationEventArgs(Point3 position, float yaw, float pitch, bool onGround, List<PositionElement> relative)
        {
            Position = position;
            Yaw = yaw;
            this.pitch = pitch;
            OnGround = onGround;
            Relative = relative;
        }
    }
    public class OpenWindowEventArgs
    {
        public int Id { get; private set; }
        public WindowType WinType { get; private set; }
        public string Name { get; private set; }

        public OpenWindowEventArgs(int id, WindowType winType, string name)
        {
            Id = id;
            WinType = winType;
            Name = name;
        }
    }
    public class WindowItemsEventArgs
    {
        public int id { get; private set; }
        public  MyProperty { get; private set; }
    }
}
