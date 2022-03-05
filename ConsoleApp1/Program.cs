using MinecraftLibrary.Client;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{



    public partial class Program
    {
        



        public static void Main()
        {
            Console.WriteLine("StartProgramm");
            MinecraftClient client = new MinecraftClient();
            client.Host = "nexus1.su";
            client.Port = 25565;
            client.Nickname = "Title_";
            
            client.Connect();
            Console.WriteLine("Ok");
            Console.ReadLine();
        }
        static string atrr(string id)
        {
            return $"[PacketInfo(" + id + ", 740, PacketCategory.Game, PacketSide.Client)]";
        }
    }

}


