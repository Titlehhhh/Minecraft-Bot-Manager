using MinecraftLibrary.API;
using MinecraftLibrary.API.Types.Chat;
using MinecraftLibrary.Client;
using MinecraftLibrary.Client.Service;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("StartProgramm");

            IServerInfoService serverInfoService = new ServerInfoService();
            try
            {
               

                ServerInfo info =  serverInfoService.GetServerInfoAsync("nexus1.su", 25565).Result;
                Console.WriteLine(info.ToString());
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: "+e);
            }
            Console.WriteLine("stop");
            Console.ReadLine();
        }        
    }

}


