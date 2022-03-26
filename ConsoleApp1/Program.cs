using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.Service;
using System.Net.Sockets;

namespace ConsoleApp1
{
    public  class Program
    {
        public string GG { get; set; }
        public static void Main()
        {
            MinecraftClient client = new MinecraftClient()
            {
                Nickname = "Title_",
                IsAuth = false,
                Host = "nexus1.su",
                Port = 25565
            };
            client.Start();
            Console.ReadLine();
            
            
        }
    }

}


