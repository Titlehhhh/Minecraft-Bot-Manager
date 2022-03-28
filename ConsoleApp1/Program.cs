using MinecraftLibrary;
using MinecraftLibrary.API.Types.Chat;

namespace ConsoleApp1
{
    public class Program
    {
        public string GG { get; set; }



        public static void Main()
        {
            Console.WriteLine("StartApp");

            for (int i = 0; i <= 2; i++)
            {
                CreateClient(("NET_BOT_0" + i)).StartAsync();
                //Thread.Sleep(10000);
            }



            Console.WriteLine("Starting");
            Console.ReadLine();


        }
        private static MinecraftClient CreateClient(string nick)
        {
            MinecraftClient client = new MinecraftClient()
            {
                Nickname = nick,
                IsAuth = false,
                Host = "192.168.1.194",
                Port = 54155
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
            client.PacketReceived += (s, p) =>
            {
                //Console.WriteLine("Пришел пакет: "+p.GetType().Name);
            };
            return client;
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


