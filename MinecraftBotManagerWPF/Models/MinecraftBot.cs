using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Geometry;
using System;
using System.Net.Sockets;

namespace MinecraftBotManagerWPF
{
    public delegate void MessageReceivedHandler(ChatMessage message);

    public class MinecraftBot : IMinecraftHandler
    {
        public event MessageReceivedHandler? MessageReceived;

        private readonly IPluginInvoker _invoker;
        public IPluginHost PluginHost { get; private set; }

        public MinecraftClient Client { get; private set; }


        public MinecraftBot(GameProfile gameProfile, TcpClient tcpClient)
        {
            Client = new MinecraftClient(gameProfile, this, tcpClient);
            PluginHost = new PluginHost(Client);
            _invoker = new PluginInvoker(PluginHost);
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
