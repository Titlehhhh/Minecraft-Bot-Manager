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
                Nickname = "Title_2",
                IsAuth = false,
                Host = "127.0.0.1",
                Port = 53722
            };
            client.LoginSuccesed += (s, e) =>
            {
                Console.WriteLine("Login Succes: " + e);
            };
            client.LoginRejected += (s, e) =>
            {
                Console.WriteLine("Login failed: " + JsonToStr(ChatMessage.Parse(e)));

            };
            client.GameRejected += (s, e) =>
            {
                Console.WriteLine("Вы были кикнуты: " + ChatMessage.Parse(e).Text);
            };
            client.ConnectionLosted += (s, e) =>
            {
                Console.WriteLine("Подключение прервано: " + e.StackTrace);
            };
            client.MessageReceived += (s, e) =>
            {
                Console.WriteLine("Chat: " + ChatMessage.Parse(e).Text);
            };
            client.Connected += (s) =>
            {
                Console.WriteLine("Connected");
            };
            client.GameJoined += (s) =>
            {
                Console.WriteLine("Game Join!");
            };

            client.Start();
            Console.WriteLine("Starting");
            Console.ReadLine();


        }

        private static string JsonToStr(ChatMessage message)
        {
            string result = message.Text;
            foreach (var extr in message.Extra)
            {
                result += JsonToStr(extr);
            }
            return result;
        }
    }

}


