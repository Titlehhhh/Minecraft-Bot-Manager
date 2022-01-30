
using MinecraftLibrary.API.Networking;
using MinecraftLibrary.API.Protocol;
using MinecraftLibrary.Core.Protocol;
using MinecraftLibrary.Networking.Session;
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
            ITcpClientSession tcpClient = new TcpClientSession("nexus1.su", 25565);
            Console.WriteLine("Asd");
            IPacketReader reader = new PacketReader(tcpClient, 740);
            tcpClient.ConnectedChanged += (s, e) =>
            {
                Console.WriteLine("Connect");
            };
            tcpClient.Connect();
            Console.ReadLine();
        }
    }
}
