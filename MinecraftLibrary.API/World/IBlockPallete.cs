using MinecraftLibrary.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.World
{
    public interface IBlockPallete
    {
        Material FromId(int id);
        bool IdHasMeta { get; }
    }
}
