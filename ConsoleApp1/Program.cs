using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System.Net.NetworkInformation;
using System.Reflection.PortableExecutable;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            foreach (NetworkInterface inter in NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.WriteLine("name: "+inter.Name);
                foreach(var adrr in inter.GetIPProperties().UnicastAddresses)
                {
                    Console.WriteLine(" "+adrr.Address.ToString());
                }
            }
        }
    }


}


