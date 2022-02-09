using System.ComponentModel;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using System.Runtime.CompilerServices;

namespace MinecraftLibrary.API.Bot
{
    public abstract class PacketListener : INotifyPropertyChanged, IDisposable
    {
        protected IPacketReader Reader;
        protected IPacketWriter Writer;
        protected ITcpClientSession Session;
        public PacketListener(IPacketReader reader, IPacketWriter writer, ITcpClientSession session)
        {
            Reader = reader;
            Writer = writer;
            Session = session;
            RegisterEvents();
        }
        protected virtual void RegisterEvents()
        {
            Writer.PacketSentEvent += Writer_PacketSentEvent;
            Writer.PacketSendEvent += Writer_PacketSendEvent;
            Reader.PacketProcessedEvent += Reader_PacketProcessedEvent;
            Session.Connected += Session_Connected;
            Session.DisconnectedEvent += Session_DisconnectedEvent;
        }

        private void Session_DisconnectedEvent(object? sender, Networking.Events.DisconnectedEventArgs e)
        {
            Discconected();
        }

        private void Session_Connected(object? sender, Networking.Events.ConnectedEventArgs e)
        {
            Connected();
        }

        private void Reader_PacketProcessedEvent(object? sender, Protocol.Events.PacketProcessedEventArgs e)
        {
            HandlePacket(e.Packet);
        }

        private void Writer_PacketSendEvent(object? sender, Protocol.Events.PacketSendEventArgs e)
        {
            PacketSend(e.Packet);
        }

        private void Writer_PacketSentEvent(object? sender, Protocol.Events.PacketSentEventArgs e)
        {
            PacketSent(e.Packet);
        }

        protected virtual void HandlePacket(IPacket packet)
        {

        }
        protected virtual void PacketSent(IPacket packet)
        {

        }
        protected virtual void PacketSend(IPacket packet)
        {

        }
        protected virtual void Connected()
        {

        }
        protected virtual void Discconected()
        {

        }


        protected virtual void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        protected virtual void UnRegisterEvents()
        {
            Writer.PacketSentEvent -= Writer_PacketSentEvent;
            Writer.PacketSendEvent -= Writer_PacketSendEvent;
            Reader.PacketProcessedEvent -= Reader_PacketProcessedEvent;
        }
        public void Dispose()
        {
            UnRegisterEvents();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
