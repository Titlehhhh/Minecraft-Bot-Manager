using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Service;
using System.Net.Sockets;

namespace ConsoleApp1
{
    public class Program
    {
        public string GG { get; set; }
        public static void Main()
        {
            Console.WriteLine("Start App");
            MinecraftClient client = new MinecraftClient()
            {
                Nickname = "Title_",
                IsAuth = false,
                Host = "nexus1.su",
                Port = 25565
            };
            client.LoginSuccesed += (s, e) =>
            {
                Console.WriteLine("Login Succes: " + e);
            };
            client.LoginRejected += (s, e) =>
            {
                Console.WriteLine("Login Failed: " + e);
            };
            client.GameRejected += (s, e) =>
            {
                Console.WriteLine("Вы были кикнуты: " + ChatMessage.Parse(e).Text);
            };
            client.ConnectionLosted += (s, e) =>
            {
                Console.WriteLine("Подключение прервано: " + e.Message);
            };
            client.MessageReceived += (s, e) =>
            {
                Console.WriteLine("Chat: " + ChatMessage.Parse(e).Text);
            };
            client.Connected += (s) =>
            {
                Console.WriteLine("Connected");
            };

            client.Start();
            Console.WriteLine("Starting");
            Console.ReadLine();


        }
    }

}


