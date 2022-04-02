﻿using MinecraftLibrary;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;
using System.ComponentModel.Composition;


namespace MinecraftBotManager.PluginContracts
{
    public delegate void PluginHandler(IPluginHost bot, IPlugin plugin);
    public interface IPlugin
    {
        [Import]
        public MinecraftClient Client { get; set; }

        void Inizialize();
        void UnLoaded();

        void OnLoginSucces(Guid uuid);
        void OnConnected();

        void OnDisconnected();
        void OnPositionRotation(Point3 pos, Rotation rot, bool onGround);

        void OnLoginReject(ChatMessage reason);
        void OnChat(ChatMessage message);
        void OnGameKick(ChatMessage reason, Exception e = null);


    }
}