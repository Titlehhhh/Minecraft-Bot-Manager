using MinecraftLibrary.MinecraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MinecraftLibrary.Interfaces;
using MinecraftLibrary.Data;
using MinecraftLibrary;
using System.Text.RegularExpressions;
using System.Data;
using System.Diagnostics;
using System.IO;

namespace ModulesLibrary
{
    [DisplayName("Физический движок")]
    [Description("Предоставляет стандартный физический движок майнкрафта")]
    public class PhysicEngine : MinecraftModule
    {
        public PhysicEngine(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {
        }
    }
    [DisplayName("Авто-Рыбалка")]
    public class AutoFish : MinecraftModule
    {
        public AutoFish(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {

        }
    }
    [Description("Новый59")]
    public class ChatSolver2 : MinecraftModule
    {
        private static DataTable dataTable = new DataTable();
        public const string PathCalc = @"C:\Users\Пользователь\Desktop\Resources\Parser.exe";
        private static readonly Regex regex = new Regex(@"Бот реши:(.+)\Z", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public ChatSolver2(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {
            ChatAdd("E1");
        }
        public override void ServerChat(string json)
        {
            
            string msg = Regex.Replace(ChatParser.ParseText(json), @"§[0-9a-fr]", "");

            Match match = regex.Match(msg);
            if (match.Success)
            {
                string exp = match.Groups[1].Value;
                ChatAdd("MSGGGGG: "+exp,false);
                try
                {
                    Task.Run(() =>
                    {
                        Process process = new Process();
                        ProcessStartInfo startInfo = new ProcessStartInfo();
                        startInfo.FileName = PathCalc;
                        startInfo.RedirectStandardInput = true;
                        startInfo.RedirectStandardOutput = true;
                        startInfo.UseShellExecute = false;
                        startInfo.RedirectStandardError = true;
                        startInfo.CreateNoWindow = true;
                        process.StartInfo = startInfo;
                        process.Start();
                        StreamWriter sw = process.StandardInput;
                        sw.WriteLine(exp);
                        string otvet = process.StandardOutput.ReadToEnd();
                        string error = process.StandardError.ReadToEnd();
                        
                        if (error.Equals(""))
                        {
                            
                            ChatAdd("otvet: "+otvet);
                            if (otvet.Trim() == "[]")
                            {
                                SendText("!" + "Действительных корней нет!");
                            }
                            else
                            SendText("!"+otvet.Trim().Replace(":","="));
                        }
                        else
                        {
                           // ChatAdd("§4Erorr: " + error);

                            
                        }

                    });

                }
                catch
                {
                    SendText("error2");
                }
                //ChatAdd("asd");
            }

        }
    }

}
