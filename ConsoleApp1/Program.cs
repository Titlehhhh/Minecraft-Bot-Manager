using System.Net.NetworkInformation;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            foreach (NetworkInterface inter in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine("name: " + inter.Name);
                foreach (var adrr in inter.GetIPProperties().UnicastAddresses)
                {
                    Console.WriteLine(" " + adrr.Address.ToString());
                }
            }
        }
    }


}


