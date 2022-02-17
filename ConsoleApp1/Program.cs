using MojangSharp;
using MojangSharp.Api;
using MojangSharp.Endpoints;
using MojangSharp.Responses;
using System;

namespace ConsoleApp1
{
    public partial class Program
    {
        public static void Main()
        {
            AuthenticateResponse auth = new Authenticate(new Credentials() { Username = "Title_", Password = "12456" }).PerformRequestAsync().Result;
            if (auth.IsSuccess)
            {
                
                Console.WriteLine($"  Access token: {auth.AccessToken}");
                Console.WriteLine($"  Client token: {auth.ClientToken}");
                Console.WriteLine($"  Profiles: {auth.AvailableProfiles.Count}");
                Console.WriteLine($"  Profile name: {auth.SelectedProfile.PlayerName}");
                if (auth.User.Properties != null)
                    Console.WriteLine($"  Properties: {auth.User.Properties.Count}");

                Response v = new Validate(auth.AccessToken).PerformRequestAsync().Result;
                if (v.IsSuccess)
                    WriteColoredLine(ConsoleColor.DarkGreen, "  Validated!");
                else
                    WriteColoredLine(ConsoleColor.DarkYellow, "  Not validated.");
            }
            else
                WriteColoredLine(ConsoleColor.Red, auth.Error.Exception == null ? auth.Error.ErrorMessage : auth.Error.Exception.Message);

            Console.ReadLine();
        }
        #region Console

        private static void WriteColoredLine(ConsoleColor color, string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor; Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        private static void WriteColoredLine(ApiStatusResponse.Status status, string message)
        {
            ConsoleColor currentColor = Console.ForegroundColor;

            ConsoleColor color = ConsoleColor.Gray;
            if (status == ApiStatusResponse.Status.Available)
                color = ConsoleColor.DarkGreen;
            if (status == ApiStatusResponse.Status.SomeIssues)
                color = ConsoleColor.DarkYellow;
            if (status == ApiStatusResponse.Status.Unavailable)
                color = ConsoleColor.Red;
            if (status == ApiStatusResponse.Status.Unknown)
                color = ConsoleColor.Gray;

            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }

        #endregion Console
    }
}
