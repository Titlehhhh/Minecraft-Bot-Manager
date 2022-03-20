﻿using MinecraftLibrary.API;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Geometry;
using ProtocolLib754;
using ProtocolLib754.Packets.Client;
using ProtocolLib754.Packets.Server;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MinecraftLibrary
{
    public class ProtocolClient : IProtocolClient
    {
        private ProtocolState subProtocol;

        public string Nickname { get; set; }
        public string Host { get; set; }
        public ushort Port { get; set; }
        public bool IsAuth { get; set; }

        #region Игровые свойства
        
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

        public Guid UUID { get; private set; }

        public Point3 Location { get; private set; }

        public Rotation Rotation { get; private set; }

        public bool IsGround { get; private set; }
        #endregion
        #region Сервисы

        private static readonly IPacketProvider packetProvider754 = new PacketProvider754();

        public IPacketManager PacketManager { get; set; }

        public TcpClientSession Session { get; private set; }

        
        #endregion

        #region События
        public event EventHandler<ProtocolClientDisconnectEventArg> Disconnected;
        public event EventHandler<ChatEventArgs> ChatMessageEvent;
        public event Action LoginSucces;
        public event Action Connected;
        public event PropertyChangedEventHandler? PropertyChanged;
        public event Action JoiningGame;
        public event Action Respawning;
        public event Action UpdatePositionRotation;
        #endregion



        #region Общие методы
        public void Disconnect()
        {

        }
        public void Connect()
        {
            Validate();

            Session = new TcpClientSession();
            if (PacketManager is null)
            {
                throw new NullReferenceException(nameof(PacketManager) + " был null");
            }
            Session.PacketFactory = this.PacketManager;

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
            Session.PacketSent -= Session_PacketSent;
            Session.PacketSend -= Session_PacketSend;
        }
        private void RegisterEvents()
        {
            Session.Connected += Session_Connected;
            Session.Disconnected += Session_Disconnected;
            Session.PacketReceived += Session_PacketReceived;
            Session.PacketSent += Session_PacketSent;
            Session.PacketSend += Session_PacketSend;
        }
        #endregion

        #region Работа с пакетами
        private void Session_Connected()
        {
            //Console.WriteLine("Connected");
            this.Connected?.Invoke();

            SendPacket(new HandShakePacket(HandShakeIntent.LOGIN, 754, Port, Host));
        }

        private void Session_PacketSent(object? sender, PacketSentEventArgs e)
        {
            //Console.WriteLine("PacketSent: " + e.Packet.GetType().Name);
            if (e.Packet is HandShakePacket)
            {
                this.SubProtocol = ProtocolState.Login;
                SendPacket(new LoginStartPacket(Nickname));
            }
        }

        private void Session_PacketSend(object? sender, PacketSendEventArgs e)
        {
            //Console.WriteLine("PacketSend: " + e.Packet.GetType().Name);
        }

        private void Session_PacketReceived(object? sender, PacketReceivedEventArgs e)
        {
            Console.WriteLine(e.Packet.GetType().Name);
            if (e.Packet is LoginDisconnectPacket)
            {
                var disconnect = e.Packet as LoginDisconnectPacket;
                Session.Disconnect();
                Disconnected?.Invoke(this, new ProtocolClientDisconnectEventArg(disconnect.Message, null, DisconnectReason.LoginRejected));
            }
            else if (e.Packet is LoginSetCompressionPacket)
            {
                var compress = e.Packet as LoginSetCompressionPacket;
                Session.CompressionThreshold = compress.Threshold;

            }
            else if (e.Packet is EncryptionRequestPacket)
            {
                //TODO
            }
            else if (e.Packet is LoginSuccessPacket)
            {
                var succes = e.Packet as LoginSuccessPacket;
                SubProtocol = ProtocolState.Game;
                this.LoginSucces?.Invoke();
                UUID = Guid.Parse(succes.UUID);

            }
            else if (e.Packet is ServerJoinGamePacket)
            {
                var join = e.Packet as ServerJoinGamePacket;

            }
            else if (e.Packet is ServerKeepAlivePacket)
            {
                var keepalive = e.Packet as ServerKeepAlivePacket;
                SendPacket(new ClientKeepAlivePacket(keepalive.PingID));
            }
            else if(e.Packet is ServerRespawnPacket)
            {
                var respawn = e.Packet as ServerRespawnPacket;
                
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
        #endregion


        #region Методы действий
        public void SendLocation(Rotation rotation, bool isGround)
        {

        }

        public void SendLocation(Point3 position, Rotation rotation, bool isGround)
        {

        }
        public void LookHead(Rotation rotation)
        {

        }

        public void LookHead(Point3 targetpos)
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
        #endregion







        private void RegisterHandShakePackets()
        {
            PacketManager.ClearAll();
            PacketManager.LoadOutputPackets(packetProvider754.ClientPackets.HandShakePackets);
        }
        private void RegisterLoginPackets()
        {
            PacketManager.ClearAll();

            PacketManager.LoadOutputPackets(packetProvider754.ClientPackets.LoginPackets);

            PacketManager.LoadInputPackets(packetProvider754.ServerPackets.LoginPackets);
        }
        private void RegisterGamePackets()
        {
            PacketManager.ClearAll();

            PacketManager.LoadOutputPackets(packetProvider754.ClientPackets.GamePackets);

            PacketManager.LoadInputPackets(packetProvider754.ServerPackets.GamePackets);
        }



        public void Close()
        {
            UnRegisterEvents();
        }
        public void Dispose()
        {
            Close();

        }
    }
}