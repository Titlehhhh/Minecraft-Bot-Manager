using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Net;

namespace MinecraftBotManager.Api.Minecraft
{
    public interface IMinecraftClient : INotifyPropertyChanged, IDisposable
    {
        int TargetProtocolVersion { get; }


        void Connect();

        void Close();
    }
}
