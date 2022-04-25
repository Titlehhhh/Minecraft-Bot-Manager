using System.Net.NetworkInformation;
using System.Net;
using System.DirectoryServices;
using MinecraftLibrary.Services;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine(new ServerInfoService().GetServerInfoAsync("192.168.1.153",53687).Result.Icon.Length);
        }
    }


}


