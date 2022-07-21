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
