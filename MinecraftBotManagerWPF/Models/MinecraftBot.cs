using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.Geometry;
using System;
using System.ComponentModel;
using MinecraftLibrary;
using MinecraftBotManager.PluginContracts;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.API.Networking;

namespace MinecraftBotManagerWPF
{
    

    public class MinecraftBot : IDisposable, IMinecraftHandler
    {
        private readonly MinecraftClient _client;

        private readonly IPluginInvoker _invoker;

        internal MinecraftBot(MinecraftClient client, IPluginInvoker pluginHost)
        {
            if (client is null)
                throw new ArgumentNullException(nameof(client));
            if (pluginHost is null)
                throw new ArgumentNullException(nameof(pluginHost));

            _client = client;
            _invoker = pluginHost;
        }


        public void Dispose()
        {
            _client.Dispose();
        }

        public void OnChat(string message)
        {
            _invoker.Invoke(p => p.OnChat(message));
        }

        public void OnConnect()
        {
            _invoker.Invoke(p => p.OnConnected());
        }

        public void OnDisconnect()
        {
            _invoker.Invoke(p => p.OnDisconnect());
        }

        public void OnDisconnect(Exception e)
        {
            _invoker.Invoke(p => p.OnDisconnect(e));
        }

        public void OnDisconnect(string reason)
        {
            _invoker.Invoke(p => p.OnDisconnect(ChatMessage.Parse(reason)));
        }

        public void OnGameJoined()
        {
            _invoker.Invoke(p => p.OnGameJoined());
        }

        public void OnLoginReject(ChatMessage message)
        {
            _invoker.Invoke(p => p.OnLoginReject(message));
        }

        public void OnLoginSucces(Guid uuid)
        {
            throw new NotImplementedException();
        }

        public void OnPacketReceived(IPacket packet)
        {
            throw new NotImplementedException();
        }

        public void OnPositionRotation(Point3 pos, Rotation rot, bool onGround)
        {
            throw new NotImplementedException();
        }
    }
}
