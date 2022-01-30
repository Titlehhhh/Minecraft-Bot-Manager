using MinecraftLibrary.Geometry;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Models
{
    /// <summary>
    /// Предоставляет высокий уровень абстракции для работы с протоколом
    /// </summary>
    public interface IBotObject : INotifyPropertyChanged
    {
        int Health { get; set; }
        Point3 Position { get; set; }


    }
}
