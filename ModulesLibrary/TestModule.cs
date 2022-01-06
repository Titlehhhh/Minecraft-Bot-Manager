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
    [DisplayName("Физический движок")]

    public class PhysicEngine : MinecraftModule
    {
        private bool need = true;
        private World world;
        private long tick = 0;
        Task gameLoop;
        public PhysicEngine(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {


        }
        ManualResetEvent ChunkLoad = new ManualResetEvent(false);
        double VelY = 0;
        bool physics = false;
        public override void Start()
        {

            world = MainBot.World;


            gameLoop = Task.Run(() =>
            {

                //Thread.Sleep(3500);
                ChatAdd("Start");
                //
                ChunkLoad.Reset();
                Stopwatch stopWatch = new Stopwatch();
                Location player = new Location(MainBot.Position.X, 0, MainBot.Position.Z);

                if (world[player.ChunkX, player.ChunkZ] != null)
                {                   
                    physics = true;
                }
                else
                {
                    ChunkLoad.WaitOne();
                }

                while (true)
                {
                    stopWatch.Start();
                    if (!need)
                        break;

                    if (physics)
                    {
                        
                        
                        Location playerpos1 = new Location(MainBot.Position.X, MainBot.Position.Y, MainBot.Position.Z);
                        Location playerpos2 = Movement.HandleGravity(world, playerpos1, ref VelY);
                        //VelY += 0.1;
                        bool b = Movement.IsOnGround(world, playerpos2);
                        if (!b)
                        {
                            MainBot.UpdatePosition(new Vector3d(0, VelY, 0), b);
                        }
                        else
                        {
                            VelY = 0;                            
                        }


                    }
                    stopWatch.Stop();
                    int elapsed = stopWatch.Elapsed.Milliseconds;
                    if (elapsed < 100)
                        Thread.Sleep(100 - elapsed);
                }
                ChatAdd("GameLoopStop");


            });
        }
        public override void WorldUpdate(int chunkX, int chunkZ)
        {
            Location player = new Location(MainBot.Position.X, 0, MainBot.Position.Z);
            
            if (player.ChunkX == chunkX && player.ChunkZ == chunkZ)
            {
                
                ChunkLoad.Set();
            }

        }
        public override void OnHealthUpdate(float health, int food)
        {

            if (health == 0)
            {
                MainBot.RespawnPlayer();
            }

        }
        public override void OnPositionRotation(Point3d pos, float yaw, float pitch)
        {
            physics = true;
            ChunkLoad.Set();
            VelY = 0;
        }

        public override void Stop()
        {
            ChatAdd("Stop");
            need = false;
            Task.Run(() =>
            {
                gameLoop.Wait();

            });
        }
        public override void UnLoad()
        {
            need = false;
            Task.Run(() =>
            {
                gameLoop.Wait();               
            });
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
