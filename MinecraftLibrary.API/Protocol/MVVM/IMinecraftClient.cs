using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.API.Protocol.MVVM
{
    public interface IMinecraftClient : INotifyPropertyChanged
    {
        public string Nickname { get; set; }
    }
}
