using MinecraftBotManager.Api.Minecraft;
using System.ComponentModel;
using System.Net;

namespace MinecraftBotManager.Core.Minecraft.Clients
{


    public class MinecraftClient754 : IMinecraftClient, IDisposable
    {
        public int TargetProtocolVersion => 754;

        
        public event PropertyChangedEventHandler? PropertyChanged;

        public void Close()
        {

            //Dispose();
        }

        public void Connect()
        {

        }

        public void Dispose()
        {

        }


    }
}
