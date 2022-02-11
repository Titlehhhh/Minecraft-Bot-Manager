using Ionic.Zlib;
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Networking.Attributes;
using MinecraftLibrary.API.Networking.IO;
using MinecraftLibrary.Utils;
using ProtocolLib340;
using ProtocolLib340.Packets.Client.HandShake;
using ProtocolLib340.Packets.Client.Login;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftLibrary.Core
{
    public class MinecraftClient : INotifyPropertyChanged
    {
        private static readonly int ZERO_VARLENGTH = GetVarIntLength(0);


        public string Host { get; set; }
        public int Port { get; set; }
        public bool CheckSession { get; set; }
        public int ProtocolVersion { get; set; }

        private int CompressionThreshold = 0;

        public Guid UUID { get; internal set; }

        Dictionary<int, Type> ServerLoginPackets = new Dictionary<int, Type>();
        Dictionary<int, Type> ServerGamePackets = new Dictionary<int, Type>();

        Dictionary<Type, int> ClientHandShakePackets = new Dictionary<Type, int>();
        Dictionary<Type, int> ClientLoginPackets = new Dictionary<Type, int>();
        Dictionary<Type, int> ClientGamePAckets = new Dictionary<Type, int>();

        Dictionary<int, Type> ServerPackets;
        Dictionary<Type, int> ClientPackets;

        public ProtocolState State
        {
            get { return state; }
            set
            {
                state = value;
                switch (value)
                {
                    case ProtocolState.HandShake:
                        ClientPackets = ClientHandShakePackets;
                        ServerPackets = ServerLoginPackets;
                        break;
                    case ProtocolState.Login:
                        ClientPackets = ClientLoginPackets;
                        break;
                    case ProtocolState.Game:
                        ClientPackets = ClientGamePAckets;
                        ServerPackets = ServerGamePackets;
                        break;
                }
            }
        }
        public MinecraftStream NetStream { get; private set; }

        private TcpClient tcpClient;
        private ProtocolState state;

        public MinecraftClient()
        {


            ServerLoginPackets = PacketPallete340.ServerLoginPackets;
            ServerGamePackets = PacketPallete340.ServerGamePackets;

            ClientHandShakePackets = PacketPallete340.ClientHandShakePackets;
            ClientLoginPackets = PacketPallete340.ClientLoginPackets;
            ClientGamePAckets = PacketPallete340.ClientGamePAckets;


        }
        private async Task<(int, MinecraftStream)> ReadPacketAsync()
        {

            int len = await NetStream.ReadVarIntAsync();
           // int len = 0;
           
            //Console.WriteLine(len);
            byte[] receivedata = new byte[len];

           // tcpClient.Client.Receive(receivedata, 0, 1, SocketFlags.None);
           // Console.WriteLine("sad");
            await NetStream.ReadAsync(receivedata.AsMemory(0, len));
            int id = 0;
             var ms = new MinecraftStream(receivedata);

            if (CompressionThreshold > 0)
            {
                int sizeUncompressed = ms.ReadVarInt();
                if (sizeUncompressed != 0)
                {
                    //receivedata = ZlibUtils.Decompress(ms, sizeUncompressed);
                    //ms.Write(receivedata);
                    ZlibStream zlibStream = new ZlibStream(ms.BaseStream, CompressionMode.Decompress);
                    ms.BaseStream = zlibStream;
                    id = ms.ReadVarInt();
                }
            }
            else
            {
                id = ms.ReadVarInt();
            }
            return (id, ms);

        }

        private async Task ReadLoop()
        {
            while (true)
            {
                Console.WriteLine("Read");
                (int id, MinecraftStream stream) = await ReadPacketAsync();
                if (ServerPackets.ContainsKey(id))
                {
                    Console.Write("Пакет: " + id);
                    IPacket packet = CreatePAcket(ServerPackets[id]);
                    packet.Read(stream);
                    stream.Close();
                    HandlePacket(packet);
                }
                else
                {
                    Console.WriteLine("Пакет не найден!");
                }

            }
        }

        private static IPacket CreatePAcket(Type t)
        {
            return (IPacket)Activator.CreateInstance(t);
        }

        private void HandlePacket(IPacket packet)
        {
            Console.WriteLine(" " + packet.GetType().Name);
        }

        private void PacketSend(IPacket packet)
        {
            Console.WriteLine(" " + packet.GetType().Name);
        }
        private void PacketSent(IPacket packet)
        {
            Console.WriteLine(" " + packet.GetType().Name);
            if (packet is HandShakePacket)
            {
                // State = ProtocolState.Login;
                //SendPacket(new LoginStartPacket("Title_"));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public async void StartClient()
        {
            State = ProtocolState.HandShake;
            tcpClient = new TcpClient(Host,Port);
            //tcpClient.ReceiveTimeout = 30 * 1000;
            //tcpClient.ReceiveBufferSize = 1024 * 1024;            
            Console.WriteLine("Connect");
            NetStream = new MinecraftStream(new NetworkStream(tcpClient.Client));
            //ReadLoop();
            HandShakePacket handShakePacket = new HandShakePacket(HandShakeIntent.LOGIN, 340, Port, Host);
            State = ProtocolState.Login;
            SendPacket(0x00, handShakePacket);
            LoginStartPacket loginStart = new LoginStartPacket("GHaf");
            SendPacket(0x00, loginStart);

            (int id, MinecraftStream stream) = await ReadPacketAsync();
            Console.WriteLine(id);
        }
        public void Discconect()
        {

        }

        public void SendChat(string msg)
        {

        }

        public void SendPacket(IPacket packet)
        {
            try
            {
                int id = ClientPackets[packet.GetType()];
                SendPacket(id, packet);
            }
            catch
            {

            }
        }
        public void SendPacket(int id, IPacket packet)
        {
            
            PacketSend(packet);
            if (CompressionThreshold > 0)
            {
                using (MinecraftStream packetStream = new MinecraftStream())
                {
                    packet.Write(packetStream);
                    int to_Packetlength = (int)packetStream.Length;
                    if (to_Packetlength >= CompressionThreshold)
                    {
                        LongPacket(packetStream, to_Packetlength);
                    }
                    else
                    {
                        ShortPacket(packetStream);
                    }
                }
            }
            else
            {
                DisableCompress(packet, id);
            }
            PacketSent(packet);
        }

        private void DisableCompress(IPacket packet, int id)
        {
            MemoryStream memory = new MemoryStream();
            using (MinecraftStream packetStream = new MinecraftStream())
            {
                
                packet.Write(packetStream);
                int Packetlength = (int)packetStream.Length;

                NetStream.WriteVarInt(GetVarIntLength(id) + Packetlength);
                NetStream.WriteVarInt(id);

                //MinecraftStream ms2 = new MinecraftStream();
                packetStream.Position = 0;
                packetStream.CopyTo(NetStream);
            }
        }

        private void LongPacket(MinecraftStream packetStream, int to_Packetlength)
        {
            using (MemoryStream memstream = new MemoryStream())
            {
                using (ZlibStream stream = new ZlibStream(memstream, CompressionMode.Compress))
                {
                    packetStream.CopyTo(stream);
                }
                packetStream.BaseStream = memstream;
            }
            int fullSize = (int)packetStream.Length + GetVarIntLength(to_Packetlength);
            NetStream.WriteVarInt(fullSize);
            NetStream.WriteVarInt(to_Packetlength);
            packetStream.Position = 0;
            packetStream.CopyTo(NetStream);
        }
        private void ShortPacket(MinecraftStream packetStream)
        {
            int fullSize = (int)packetStream.Length + ZERO_VARLENGTH;
            NetStream.WriteVarInt(fullSize);
            NetStream.WriteVarInt(0);
            packetStream.Position = 0;
            packetStream.CopyTo(NetStream);
        }

        public static int GetVarIntLength(int val)
        {
            int amount = 0;
            do
            {
                val >>= 7;
                amount++;
            } while (val != 0);

            return amount;
        }

        private void RaisePropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
    public enum ProtocolState
    {
        HandShake,
        Login,
        Game
    }
}
