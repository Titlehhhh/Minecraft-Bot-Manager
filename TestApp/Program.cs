using MinecraftClient.Crypto;
using MinecraftLibrary;
using MinecraftLibrary.MinecraftProtocol.Packets.Client.Game;
using MinecraftLibrary.MinecraftProtocol.Packets.Client.Login;
using MinecraftLibrary.MinecraftProtocol.Packets.HandShake;
using MinecraftLibrary.MinecraftProtocol.Packets.Server.Game;
using MinecraftLibrary.MinecraftProtocol.Packets.Server.Login;
using MinecraftLibrary.Palletes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClientSession bot1 = new TcpClientSession("192.168.1.153", 52134, "Title_", 340);
            bot1.PacketReceiveChanged += (p) =>
            {
                if (p.GetType() == typeof(ServerKeepAlivePacket))
                    bot1.SendPacket(new ClientKeepAlivePacket((p as ServerKeepAlivePacket).PingId));
            };
            bot1.Connect();

            Console.ReadLine();
        }
    }
}
