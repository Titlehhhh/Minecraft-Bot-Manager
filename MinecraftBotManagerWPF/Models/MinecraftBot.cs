using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;
using System;

namespace MinecraftBotManagerWPF
{
    public delegate void MessageReceivedHandler(ChatMessage message);

    public class MinecraftBot : IMinecraftHandler
    {
        public event MessageReceivedHandler? MessageReceived;

        private readonly IPluginInvoker _invoker;

        public MinecraftClient Client { get; private set; }

        public MinecraftBot()
        {
            Client = new MinecraftClient(this);
            _invoker = new PluginInvoker(new PluginHost(Client));
        }


        public void OnChat(string message)
        {
            this.MessageReceived?.Invoke(ChatMessage.Parse(message));
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
            _invoker.Invoke(p => p.OnGameKick(ChatMessage.Parse(reason)));
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
