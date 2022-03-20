﻿using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Geometry;
using MinecraftLibrary.Networking;
using MinecraftLibrary.Protocol;
using ProtocolLib754;
using ProtocolLib754.Packets.Client;
using ProtocolLib754.Packets.Server;
using System.ComponentModel;

namespace MinecraftLibrary
{
    public class ProtocolClient : IProtocolClient
    {
        private ProtocolState subProtocol;

        public string Nickname { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; }
        public ITcpClientSession Session { get; private set; }



        //public IContainer CurrentContainer { get; private set; }

        public Point3 Location { get; private set; }

        public Point3_Int ChunkLocation { get; private set; }

        public Point3_Int CnunkBlockLocation { get; private set; }

        public ProtocolState SubProtocol
        {
            get { return subProtocol; }
            private set
            {
                switch (value)
                {
                    case ProtocolState.HandShake:
                        RegisterHandShakePackets();
                        break;
                    case ProtocolState.Login:
                        RegisterLoginPackets();
                        break;
                    case ProtocolState.Game:
                        RegisterGamePackets();
                        break;
                }

                subProtocol = value;
            }
        }

        public Guid UUID => throw new NotImplementedException();

        public Rotation Rotation => throw new NotImplementedException();

        public bool IsGround => throw new NotImplementedException();

        public event EventHandler<ProtocolClientDisconnectEventArg> Disconnected;
        public event EventHandler<ServerChatEventArgs> ChatMessageEvent;
        public event Action LoginSucces;
        public event Action Connected;
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly IPacketManager PacketManager = new DefaultPacketManager();

        private IPacketProvider PacketProvider;

        public void Connect()
        {
            Validate();


            PacketProvider = new PacketProvider754();

            Session = new TcpClientSession();
            Session.Host = this.Host;
            Session.Port = this.Port;
            Session.PacketFactory = PacketManager;
            RegisterEvents();
            SubProtocol = ProtocolState.HandShake;
            Session.Connect();

        }
        private void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nickname))
            {
                throw new InvalidOperationException("Введите ник");
            }
            if (string.IsNullOrWhiteSpace(Host))
            {
                throw new InvalidOperationException("Введите хость");
            }
        }

        private void UnRegisterEvents()
        {
            Session.Connected -= Session_Connected;
            Session.Disconnected -= Session_Disconnected;
            Session.PacketReceived -= Session_PacketReceived;
            Session.PacketSend -= Session_PacketSend;
            Session.PacketSent -= Session_PacketSent;
        }
        private void Session_Connected(ITcpClientSession obj)
        {
            Console.WriteLine("Connected");
            SendPacket(new HandShakePacket(HandShakeIntent.LOGIN, 754, Port, Host));
        }

        private void Session_PacketSent(object? sender, PacketSentEventArgs e)
        {
            Console.WriteLine("PacketSent: " + e.Packet.GetType().Name);
            if (e.Packet is HandShakePacket)
            {
                this.SubProtocol = ProtocolState.Login;
                SendPacket(new LoginStartPacket(Nickname));
            }
        }

        private void Session_PacketSend(object? sender, PacketSendEventArgs e)
        {
            Console.WriteLine("PacketSend: " + e.Packet.GetType().Name);
        }

        private void Session_PacketReceived(object? sender, PacketReceivedEventArgs e)
        {
            Console.WriteLine(e.Packet.GetType().Name);
            if (e.Packet is LoginDisconnectPacket)
            {
                Session.Disconnect();
                Console.WriteLine("Disconnect: " + (e.Packet as LoginDisconnectPacket).Message);
            }
            else if (e.Packet is LoginSetCompressionPacket)
            {
                var compress = e.Packet as LoginSetCompressionPacket;
                Session.CompressionThreshold = compress.Threshold;

            }
            else if (e.Packet is EncryptionRequestPacket)
            {

            }
            else if (e.Packet is LoginSuccessPacket)
            {
                SubProtocol = ProtocolState.Game;
            }
        }

        private void Session_Disconnected(object? sender, DisconnectedEventArgs e)
        {
            UnRegisterEvents();
            Disconnected?.Invoke(this, new ProtocolClientDisconnectEventArg(e.Message, e.Exception));
        }

        private void SendPacket(IPacket packet)
        {
            Session.SendPacket(packet);
        }



        public void Disconnect()
        {

        }



        public void SendChat(string msg)
        {

        }

        public void SendLocation(bool isGround)
        {

        }

        public void SendLocation(Point3 position, bool isGround)
        {

        }

        public void SendLocation(Vector3 vector, bool isGround)
        {

        }

        public void SendLocation(Point3 position, float yaw, float pitch, bool isGround)
        {

        }

        public void SendLocation(Vector3 body, Vector3 head, bool isGround)
        {

        }

        private void RegisterHandShakePackets()
        {
            PacketManager.ClearAll();
            PacketManager.LoadOutputPackets(PacketProvider.ClientPackets.HandShakePackets);
        }
        private void RegisterLoginPackets()
        {
            PacketManager.ClearAll();

            PacketManager.LoadOutputPackets(PacketProvider.ClientPackets.LoginPackets);

            PacketManager.LoadInputPackets(PacketProvider.ServerPackets.LoginPackets);
        }
        private void RegisterGamePackets()
        {
            PacketManager.ClearAll();

            PacketManager.LoadOutputPackets(PacketProvider.ClientPackets.GamePackets);

            PacketManager.LoadInputPackets(PacketProvider.ServerPackets.GamePackets);
        }
        private void RegisterEvents()
        {
            Session.Connected += Session_Connected;
            Session.Disconnected += Session_Disconnected;
            Session.PacketReceived += Session_PacketReceived;
            Session.PacketSend += Session_PacketSend;
            Session.PacketSent += Session_PacketSent;
        }

        public void LookHead(Rotation rotation)
        {

        }

        public void LookHead(Point3 targetpos)
        {

        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void SendLocation(Rotation rotation, bool isGround)
        {
            throw new NotImplementedException();
        }

        public void SendLocation(Point3 position, Rotation rotation, bool isGround)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
