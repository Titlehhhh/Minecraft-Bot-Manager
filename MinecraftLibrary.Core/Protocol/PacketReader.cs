using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Crypto;
using MinecraftLibrary.API.Networking.Events;
using MinecraftLibrary.API.Networking.Proxy;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.API.Protocol.Events;
using MinecraftLibrary.API.Protocol.Helpres;
using MinecraftLibrary.Networking.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core.Protocol
{
    public class PacketReader : IPacketReader
    {

        public Dictionary<Type, int> RegisteredOutputPakets { get; set; }
        public Dictionary<int, Type> RegisteredInputPakets { get; set; }

        public int ProtocolVersion { get; set; }

        public ITcpClientSession Session { get; private set; }
        public bool IsEnabled { get; set; }

        public event EventHandler<DisconnectedEventArgs> DisconnectedEvent;
        public event EventHandler<PacketProcessedEventArgs> PacketProcessedEvent;
        public event EventHandler<PacketSendEventArgs> PacketSendEvent;
        public event EventHandler<PacketSentEventArgs> PacketSentEvent;

        public PacketReader( ITcpClientSession session,int protocolVersion)
        {
            if (session is null)
                throw new ArgumentNullException(nameof(session));
            if (protocolVersion <= 0)
                throw new InvalidOperationException("Версия протокола должна быть положительной");
            ProtocolVersion = protocolVersion;
            Session = session;
            Session.ConnectedChanged += Session_ConnectedChanged;
            Session.DisconnectedChanged += Session_DisconnectedChanged;
        }

        private void Session_DisconnectedChanged(object sender, DisconnectedEventArgs e)
        {
            UnregisteredEvents();
        }
        private void UnregisteredEvents()
        {
            Session.ConnectedChanged -= Session_ConnectedChanged;
            Session.DisconnectedChanged -= Session_DisconnectedChanged;
            Session.PacketReceivedChanged -= Session_PacketReceivedChanged;
        }

        private void Session_ConnectedChanged(object sender, ConnectedEventArgs e)
        {
            Session.PacketReceivedChanged += Session_PacketReceivedChanged;
            Session.ConnectedChanged -= Session_ConnectedChanged;
        }

        private void Session_PacketReceivedChanged(object sender, PacketReceivedEventArgs e)
        {
            int id = e.Data.ID;
            byte[] data = e.Data.Data;
            if (RegisteredInputPakets.ContainsKey(id))
            {
                IPacket packet = CreateInstance(RegisteredInputPakets[id]);
                using(MinecraftStream ms = new MinecraftStream(new MemoryStream(data), ProtocolVersion))
                {
                    packet.Read(ms, ProtocolVersion);
                }
                PacketProcessedEvent?.Invoke(this, new PacketProcessedEventArgs(packet));
            }
        }

        private static IPacket CreateInstance(Type t)
        {
            return (IPacket)Activator.CreateInstance(t);
        }

        public void RegisterPacketInput(int id, Type t)
        {
            RegisteredInputPakets.Add(id, t);
        }

        public void RegisterPacketOutput(int id, Type t)
        {
            RegisteredOutputPakets.Add(t, id);
        }

        public void SendPacket(IPacket packet)
        {
            if (packet is null)
                throw new ArgumentNullException(nameof(packet));
            Type t = packet.GetType();
            if (RegisteredOutputPakets.ContainsKey(t))
            {
                int id = RegisteredOutputPakets[t];

                MemoryStream ms = new MemoryStream();
                using (MinecraftStream mcs = new MinecraftStream(ms, ProtocolVersion))
                {
                    packet.Write(mcs, ProtocolVersion);
                }
                ByteBlock byteBlock = new ByteBlock(id, ms.ToArray());
                PacketSendEvent?.Invoke(this, new PacketSendEventArgs(packet));
                Session.Send(byteBlock);
                PacketSentEvent?.Invoke(this, new PacketSentEventArgs(packet));

            }
        }

        public bool UnRegisterPacketInput(int id)
        {
            return RegisteredInputPakets.Remove(id);
        }

        public bool UnRegisterPacketOutput(Type t)
        {
            return RegisteredOutputPakets.Remove(t);
        }

        public void Dispose()
        {
            UnregisteredEvents();
        }
    }

}
