using MinecraftLibrary.API.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Inventory
{
    public interface IContainer
    {
        int ID { get; }
        ContainerType ContainerType { get; }

    }
}
