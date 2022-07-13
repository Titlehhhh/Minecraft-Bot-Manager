﻿using MinecraftBotManager.Api.Minecraft;
using System.ComponentModel;
using System.Net;
using System.Runtime.CompilerServices;


namespace MinecraftBotManager.Api.Models
{

    public interface IBot : INotifyPropertyChanged
    {
        Guid Id { get; }
        BotStatus Status { get; }
        
        string Address { get; }
        string Username { get; }

        void Start();
        void Stop();

        IMinecraftClient Client { get; }



    }


}
