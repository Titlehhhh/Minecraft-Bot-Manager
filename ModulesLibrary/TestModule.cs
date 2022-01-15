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
using System.Runtime.Serialization.Formatters.Binary;
using MinecraftLibrary.Geometri;

namespace ModulesLibrary
{


    [DisplayName("Авторизатор для MstNetwork")]
    [Description("Автоматически проходит бот фильтер на падение. Вводит или регистрирует пароль. Заходит в портал на указанную \"Анку\"")]

    public class MSTAutoAuth : MinecraftModule
    {

        private float Yaw;
        private float Pitch;

        private float? _yaw;
        private float? _pitch;

        public MSTAutoAuth(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {

        }


        private double VelY = 0;
        public override void Start()
        {
            LocationReceived = false;
            PhysicsLoop = true;
            Task.Run(() =>
            {
                Stopwatch stopwatch = new Stopwatch();
                while (PhysicsLoop)
                {
                    stopwatch.Start();

                    PhysicsUpdate();
                    stopwatch.Stop();
                    int el = stopwatch.Elapsed.Milliseconds;
                    stopwatch.Reset();
                    if (el < 100)
                        Thread.Sleep(100 - el);
                }
            });

        }
        private bool LocationReceived;
        private bool PhysicsLoop = true;

        private readonly object LocationLock = new object();

        private void PhysicsUpdate()
        {
            if (!LocationReceived)
                return;
            lock (LocationLock)
            {
                for (int i = 1; i <= 2; i++)
                {
                    Point3 location = MainBot.Position;
                    if (_yaw == null || _pitch == null)
                        location = Movement.HandleGravity(MainBot.World, location, ref VelY);
                    Yaw = _yaw == null ? Yaw : _yaw.Value;
                    Pitch = _pitch == null ? Pitch : _pitch.Value;
                    SendUpdateLoc(location, Movement.IsOnGround(MainBot.World, location), _yaw, _pitch);
                }
                _yaw = _pitch = null;
            }
        }
        public void SendUpdateLoc(Point3 location, bool onGround, float? yaw = null, float? pitch = null)
        {
            int type = 0;
            if (yaw.HasValue && pitch.HasValue)
            {
                type = 1;
            }
            if (type == 0)
            {
                MainBot.UpdatePosition(location, onGround, true);
            }
            else
            {
                MainBot.UpdatePosition(location, yaw.Value, pitch.Value, onGround, true);
            }
        }
        public override void TickUpdate()
        {

            //if (LocationReceived)
            //{

            //    lock (MainBot.LocationLock)
            //    {
            //        for (int i = 1; i <= 2; i++)
            //        {
            //            PhysicsUpdate();
            //        }
            //        MainBot._yaw = null;
            //        MainBot._pitch = null;
            //    }
            //}
        }
        
        public override void WorldUpdate(int chunkX, int chunkZ)
        {
            
        }
        public override void OnHealthUpdate(float health, int food)
        {

            if (health == 0)
            {
                MainBot.RespawnPlayer();
            }

        }
        public override void OnPositionRotation(Point3 pos, float yaw, float pitch)
        {
            lock (LocationLock)
            {
                _yaw = yaw;
                _pitch = pitch;
                LocationReceived = true;
                //ChatAdd(yaw.ToString());
            }
        }


        public void UpdatePos(Point3 pos, bool isGround)
        {
            MainBot.UpdatePosition(pos, isGround);
        }
        public override void Stop()
        {
            PhysicsLoop = false;
            base.Stop();
        }
        public override void UnLoad()
        {
            PhysicsLoop = false;
            base.UnLoad();
        }
    }
   

}
