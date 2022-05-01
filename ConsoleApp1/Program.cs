using System.Net.NetworkInformation;
using System.Net;
using System.DirectoryServices;
using MinecraftLibrary.Services;
using System.IO;
using MinecraftLibrary.API.Protocol;
using ProtocolLib754;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    public static class Program
    {
        public static Dictionary<string, string> TypeToTypeDic = new Dictionary<string, string>()
        {
            {"s","string" },
            {"i","int" },
            {"l","long" },
            {"b","bool" },
            {"ba","byte[]" },
            {"d","double" },
            {"g","Guid" },
            {"sh","short" },
            {"sb","sbyte" },
            {"ul","ulong" },
            {"bt","byte" },
            {"us","ushort" },
            {"vi","int" },
            {"vl","long" },
            {"f","float" },
            {"ula","ulong[]" },
        };
        public static void Main()
        {
            string path = "codeGenrator.script";
            string source = "";
            using (StreamReader sr = new StreamReader(path))
            {
                source = sr.ReadToEnd().Trim();
            }
            Regex rg = new Regex(@"");

        }

        static Regex regex = new Regex(@"\s+");

        static string Preparing(string input)
        {
            return regex.Replace(input.TrimEnd(), " ");
        }
    }

    public class ClassUnit
    {
        public string Name { get; set; }

        public List<FieldUnit> Fields { get; set; } = new();

    }
    public class FieldUnit
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }



}


