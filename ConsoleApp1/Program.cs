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
using System.Diagnostics;

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
            string path = "codeGenerator.script";
            if (!File.Exists(path))
                File.Create(path);

            string source = "";
            using (StreamReader sr = new StreamReader(path))
            {
                source = sr.ReadToEnd().Trim();
            }
            Regex rg = new Regex(@"(?<name>[a-zA-Z_][0-9\w]+) (?<id>[0-9]+)");

            List<ClassUnit> packets = new List<ClassUnit>();

            bool packet = false;

            foreach (string line in source.Split(Environment.NewLine))
            {
                string pline = Preparing(line);
                if (pline[0] == '\t')
                {
                    pline = pline.Trim();
                    var h = pline.Split(' ');
                    packets.Last().Fields.Add(new FieldUnit(h[0], h[1]));
                }
                else
                {
                    Match match = rg.Match(pline);

                    packets.Add(new ClassUnit(match.Groups["name"].Value, match.Groups["id"].Value));
                }
            }



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
        public string ID { get; set; }

        public ClassUnit(string name, string iD)
        {
            Name = name;
            ID = iD;
        }

        public List<FieldUnit> Fields { get; set; } = new();

    }
    public class FieldUnit
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public FieldUnit(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }



}


