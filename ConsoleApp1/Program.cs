using MinecraftLibrary.API;
using MinecraftLibrary.Service;
using System.Net.Sockets;

namespace ConsoleApp1
{
    public static class Program
    {
        public static void Main()
        {
            TcpClient tcpClient = new TcpClient();

            Console.WriteLine(tcpClient.GetStream());

            Console.WriteLine("StartProgramm");

            IServerInfoService serverInfoService = new ServerInfoService();
            try
            {


                ServerInfo info = serverInfoService.GetServerInfoAsync("nexus1.su", 25565).Result;
                Console.WriteLine(info.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            Console.WriteLine("stop");
            Console.ReadLine();
        }
    }

}


