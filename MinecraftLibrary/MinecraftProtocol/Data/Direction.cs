using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftLibrary.Data
{
    /// <summary>
    /// Represents a unit movement in the world
    /// </summary>
    /// <see href="http://minecraft.gamepedia.com/Coordinates"/>
    public enum Direction : byte
    {
        South = 3,
        West = 4,
        North = 2,
        East = 5,
        Up = 1,
        Down = 0
    }
}
