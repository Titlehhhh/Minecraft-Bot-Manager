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
using System.Runtime.Serialization.Formatters.Binary;

namespace ModulesLibrary
{
    [DisplayName("Физический движок")]

    public class PhysicEngine : MinecraftModule
    {
        private bool need = true;
        private bool Need
        {
            get { return need; }
            set
            {               
                need = value;
            }
        }
        private World world;
        private long tick = 0;
        Task gameLoop;
        Location location;
        public PhysicEngine(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {

        }
        ManualResetEvent ChunkLoad = new ManualResetEvent(false);
        double VelY = 0;
        bool physics = false;
        bool old = false;
        public override void Start()
        {
            
            world = MainBot.World;
            location = new Location(MainBot.Position.X, 0, MainBot.Position.Z);
            Need = true;            
            gameLoop = Task.Run(() =>
             {
                 ChunkLoad.Reset();
                 if (!physics)
                     if (world[location.ChunkX, location.ChunkZ] == null)
                         ChunkLoad.WaitOne();
                 ChatAdd("GameLoopStart");
                 while (Need)
                 {

                     location = new Location(MainBot.Position.X, MainBot.Position.Y, MainBot.Position.Z);
                     location = Movement.HandleGravity(world, location, ref VelY);
                     bool g = Movement.IsOnGround(world, location);
                     MainBot.UpdatePosition(new Point3d(location.X, location.Y, location.Z), g);
                     if (g)
                     {
                         VelY = 0;
                     }

                     Thread.Sleep(100);
                 }

                 ChatAdd("GameloopStop: " + need);
             });



        }
        double d = 0;
        int yaw = 0;
        public override void ReadPacket(int id, byte[] data)
        {

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
                VelY = 0;
                MainBot.RespawnPlayer();
            }

        }
        public override void OnPositionRotation(Point3d pos, float yaw, float pitch)
        {
            //physics = true;


            ChunkLoad.Set();

            location = new Location(pos.X, pos.Y, pos.Z);
            //VelY = 0;
        }

        public override void Stop()
        {
            if (need)
            {
                Task.Run(() =>
                {
                    need = false;
                    gameLoop.Wait();
                });
            }
        }
        public override void UnLoad()
        {
            if (need)
            {
                Task.Run(() =>
                {
                    need = false;
                    gameLoop.Wait();
                });
            }
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

    public class AutoAuth : MinecraftModule
    {
        public AutoAuth(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {

        }
        public override void Start()
        {


        }
        public override void Stop()
        {

        }
        public override void UnLoad()
        {

        }
        public override void OnPositionRotation(Point3d pos, float yaw, float pitch)
        {
            if (pos.Y == 450)
            {
                Task.Run(() =>
                {
                    Queue<double> steps = new Queue<double>();
                    try
                    {
                        using (FileStream fs = new FileStream("Data/AutoAuth/Steps.dat", FileMode.OpenOrCreate))
                        {
                            BinaryFormatter bin = new BinaryFormatter();
                            steps = (Queue<double>)bin.Deserialize(fs);
                        }
                    }
                    finally
                    {

                    }
                    while (steps.Count > 0)
                    {
                        double vel = steps.Dequeue();
                        MainBot.UpdatePosition(new Vector3d(0, vel, 0), false);
                        Thread.Sleep(50);
                    }

                });
            }
        }
        public override void OnEntitySpawn(Entity entity)
        {

        }
        public override void OnEntityMove(Entity entity)
        {

        }
    }

}
