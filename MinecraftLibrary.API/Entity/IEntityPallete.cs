using MinecraftLibrary.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Entity
{
    public interface IEntityPallete
    {
        EntityType FromId(int id, bool living);
    }    
}
