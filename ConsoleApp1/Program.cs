using MinecraftLibrary.Core;
using System;

namespace TestApp
{
    public partial class Program
    {
        public static void Main()
        {
            Console.WriteLine("Start");
            MinecraftClient client = new MinecraftClient();
            client.Host = "192.168.1.153";
            client.Port = 54846;
            client.StartClient();
            Console.ReadLine();
        }
    }
}
