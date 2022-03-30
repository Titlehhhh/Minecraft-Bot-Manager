using MinecraftLibrary;
using MinecraftLibrary.API;
using MinecraftLibrary.API.Types.Chat;

namespace ConsoleApp1
{
    public class Program
    {
        public string GG { get; set; }



        public static void Main()
        {
            Console.WriteLine(0.GetVarIntLength());

            



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


