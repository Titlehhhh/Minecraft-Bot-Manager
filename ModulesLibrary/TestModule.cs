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
using System.Threading;
using GeometRi;

namespace ModulesLibrary
{
    [DisplayName("Физический движок6")]

    public class PhysicEngine : MinecraftModule
    {
        private bool need = true;
        private World world;
        private long tick = 0;
        Task gameLoop;
        public PhysicEngine(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {
            ChatAdd("Constructo2r");

        }
        public override void Start()
        {
            ChatAdd("Start4");
            world = MainBot.World;
            need = true;

            gameLoop =Task.Run(() =>
            {

                Thread.Sleep(2000);

                Point3d playerpos = MainBot.Position;
                double VelY = 0;

                ChatAdd("play pos: " + playerpos);

                while (need)
                {
                    
                    playerpos = MainBot.Position;
                    if (world.GetBlock(new Location(playerpos.X, playerpos.Y, playerpos.Z)).Type == Material.Air)
                    {

                        VelY = VelY * tick / 50;

                        playerpos.Y -= 0.5;
                        MainBot.UpdatePosition(playerpos, false);
                        tick += 1;
                    }
                    else
                    {
                        VelY = 0;
                        tick = 0;
                    }


                    Thread.Sleep(50);

                }


            });
        }
        public override void Stop()
        {
            ChatAdd("Stop");
            need = false;
            //gameLoop.Wait();
        }
        public override void UnLoad()
        {
            ChatAdd("Unload");
            need = false;
            //gameLoop.Wait();
        }
    }
    [DisplayName("Авто-Рыбалка")]
    public class AutoFish : MinecraftModule
    {
        public AutoFish(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {

        }
    }
    [Description("Новый91")]
    public class ChatSolver2 : MinecraftModule
    {
        private static DataTable dataTable = new DataTable();
        public const string PathCalc = @"C:\Users\Пользователь\Desktop\Resources\Parser.exe";
        private static readonly Regex regex = new Regex(@"Бот реши:(.+)\Z", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private static readonly Regex chatgame = new Regex(@"Решите пример:(.+)\Z", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        public ChatSolver2(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {

        }
        public override void ServerChat(string json)
        {

            string msg = Regex.Replace(ChatParser.ParseText(json), @"§[0-9a-fr]", "");

            Match match = regex.Match(msg);
            if (match.Success)
            {
                string exp = match.Groups[1].Value;
                ChatAdd("MSGGGGG: " + exp, false);
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

                            ChatAdd("otvet: " + otvet);
                            if (otvet.Trim() == "[]")
                            {
                                //SendText("!" + "Действительных корней нет!");
                            }
                            //else
                            //SendText("!"+"");
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
            match = chatgame.Match(msg.Trim());
            if (match.Success)
            {

                string exp = match.Groups[1].Value;
                ChatAdd(exp);
                try
                {
                    string otvet = dataTable.Compute(exp, null).ToString();
                    SendText("!" + otvet);
                }
                catch
                {
                    ChatAdd("Ошибка");
                }
            }

        }
    }

}
