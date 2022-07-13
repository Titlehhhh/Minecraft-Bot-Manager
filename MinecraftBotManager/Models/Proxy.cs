using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Starksoft.Aspen.Proxy;

namespace MinecraftBotManager.Models
{
    public partial class Proxy : ObservableObject
    {
        private string address;

        public string Address
        {
            get => address;
            set => SetProperty(ref address, value);
        }

        private ProxyType type;

        public ProxyType Type
        {
            get => type;
            set => SetProperty(ref type, value);
        }


    }
}
