
using MinecraftLibrary.Data;
using MinecraftLibrary.Geometri;
using MinecraftLibrary.Interfaces;
using MinecraftLibrary.MinecraftProtocol;
using MinecraftLibrary.MinecraftProtocol.Data.PlayerInfo;
using MinecraftLibrary.MinecraftProtocol.Packets.Client.Game;
using MinecraftLibrary.MinecraftProtocol.Packets.Server.Game;
using Starksoft.Net.Proxy;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading.Tasks;



namespace MinecraftLibrary.MinecraftModels
{

    [Serializable]
    public class BotObject : IDeserializationCallback, INotifyPropertyChanged
    {
        

        [NonSerialized]
        public object LocationLock = new object();
        public IMainViewModelController MainViewModelController
        {
            get => modelController;
            set
            {
                if (modelController is null)
                {
                    CreateModules(value);
                    modelController = value;
                }
                else
                {
                    throw new Exception("Модель контроллер уже есть!");
                }
            }
        }
        #region Приватные поля

        #region Сериализуемые
        private string nickname = "";
        private string version = "1.12.2";
        private string host = "";
        private ushort port = 0;
        private string proxyHost = "";
        private int proxyPort = 0;
        private ProxyType proxyType;
        #endregion

        #region Не сериализуемые
        [NonSerialized]
        private IMainViewModelController modelController;
        [NonSerialized]
        World world;
        [NonSerialized]
        private TcpClientSession client;
        [NonSerialized]
        private RunningStatus status;
        [NonSerialized]
        private string gamemode;
        [NonSerialized]
        private string uUID;
        [NonSerialized]
        private float health;
        [NonSerialized]
        private string current_Slot;
        [field: NonSerialized]
        public int ProtocolVersion { get; private set; }

        public void OnDeserialization(object sender)
        {
            Modules = new ObservableCollection<MinecraftModule>();
            if (ModulesTypes is null)
                ModulesTypes = new ObservableCollection<string>();
            ModulesTypes.GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToList().ForEach(x => ModulesTypes.Remove(x));
            Inizialize();
        }

        private void ModulesTypes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {


        }

        #endregion

        #endregion

        #region Свойства
        public string Nickname
        {
            get => nickname;
            set
            {
                nickname = value;

            }
        }
        public string Version
        {
            get
            {
                return version;
            }
            set
            {
                version = value;

            }
        }
        public string Host
        {
            get { return host; }
            set
            {
                host = value;


            }
        }
        public ushort Port
        {
            get => port;
            set
            {
                port = value;

            }
        }
        public string ProxyHost
        {
            get => proxyHost;
            set
            {
                proxyHost = value;
            }
        }
        public int ProxyPort
        {
            get => proxyPort;
            set
            {
                client.ProxyPort = proxyPort = value;

            }
        }
        public ProxyType PrxType
        {
            get => proxyType;
            set
            {
                proxyType = value;
            }
        }


        public RunningStatus StatusLaunched
        {
            get { return status; }
            private set
            {
                status = value;
                RaisePropertyChanged();
            }
        }
        [NonSerialized]
        private Point3 position = new Point3();

        public Point3 Position
        {
            get { return position; ; }
            set
            {
                position = value;
                RaisePropertyChanged();
            }
        }
        [NonSerialized]
        private float yaw;

        public float Yaw
        {
            get { return yaw; }
            set
            {

                yaw = value;
                RaisePropertyChanged();
            }
        }
        [NonSerialized]
        private float pitch;

        public float Pitch
        {
            get { return pitch; }
            set
            {
                pitch = value;
                RaisePropertyChanged();
            }
        }

        //public Dispather Dispather { get; set; }

        [field: NonSerialized]
        public ObservableCollection<ChatMessage> ChatQueue { get; set; } = new ObservableCollection<ChatMessage>();
        [field: NonSerialized]
        public ObservableCollection<MinecraftModule> Modules { get; set; } = new ObservableCollection<MinecraftModule>();

        public ObservableCollection<string> ModulesTypes { get; set; } = new ObservableCollection<string>();

        public World World
        {
            get => world;
        }

        [NonSerialized]
        private Dictionary<Guid, string> online;
        public Dictionary<Guid, string> OnlinePlayers => online ?? (online = new Dictionary<Guid, string>());


        public void AddModule(Type t)
        {

            //Некоторая обработка
            MinecraftModule module = Activator.CreateInstance(t, this, this.MainViewModelController) as MinecraftModule;
            if (module != null)
            {
                Modules.Add(module);
                ModulesTypes.Add(t.FullName);
                if (StatusLaunched == RunningStatus.Launched)
                {
                    module.Start();
                }
            }

        }
        public void RemoveType(Type t)
        {
            MinecraftModule runModule = Modules.FirstOrDefault(x => x.GetType() == t);
            runModule.UnLoad();
            runModule.Stop();
            Modules.Remove(runModule);
            ModulesTypes.Remove(t.FullName);

        }

        public string Gamemode
        {
            get => gamemode;
            private set
            {
                gamemode = value;
                RaisePropertyChanged();
            }
        }
        public string UUID
        {
            get => uUID;
            private set
            {
                uUID = value;
                RaisePropertyChanged();
            }
        }
        public float Health
        {
            get => health;
            private set
            {
                health = value;
                RaisePropertyChanged();
            }
        }
        public string Current_Slot
        {
            get => current_Slot;
            private set
            {
                current_Slot = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public BotObject()
        {
            Inizialize();
        }

        private void Inizialize()
        {
            ModulesTypes.CollectionChanged += ModulesTypes_CollectionChanged;
            ChatQueue = new ObservableCollection<ChatMessage>();
            position = new Point3();

            


        }

        public BotObject(string nickname, string version, string host, ushort port, string proxyHost, int proxyPort)
        {
            Nickname = nickname;
            Version = version;
            Host = host;
            Port = port;
            ProxyHost = proxyHost;
            ProxyPort = proxyPort;

            Inizialize();
        }

        private void CreateModules(IMainViewModelController controller)
        {
            Modules.Clear();
            ModulesTypes.ToList().ForEach(m =>
            {
                try
                {
                    MinecraftModule module = (MinecraftModule)Activator.CreateInstance(TypeExt.GetType(m), this, controller);

                    Modules.Add(module);

                }
                catch
                {
                    ModulesTypes.Remove(m);
                }
            });
        }

        [NonSerialized]
        private Dictionary<int, Entity> entities;
        public Dictionary<int, Entity> Entities => entities ?? (entities = new Dictionary<int, Entity>());
        /// <summary>
        /// Запускает бота
        /// </summary>        
        public void StartClient()
        {
            LocationLock = new object();
            System.Diagnostics.Debug.WriteLine("StartBot: " + Nickname);
            Position = Point3.Zero;
            world = new World();
            ProtocolVersion = MCVer2ProtocolVersion(version);
            System.Diagnostics.Debug.WriteLine("Version: " + version);
            System.Diagnostics.Debug.WriteLine("ProtocolVersion: " + ProtocolVersion);
            ChatQueue.Clear();

            if (ProtocolVersion == 0)
            {
                StatusLaunched = RunningStatus.None;
                return;
            }

            Block.Palette = PalletesExtensions.GetBlockPalette(ProtocolVersion);

            if (StatusLaunched == RunningStatus.None)
                Task.Run(() =>
                {
                    try
                    {
                        StatusLaunched = RunningStatus.Initialization;

                        client = new TcpClientSession(Host, Port, ProxyHost, ProxyPort, proxyType, Nickname, ProtocolVersion);
                        client.ProtocolVersion = ProtocolVersion;
                        client.PacketSentChanged += (e) =>
                        {

                        };
                        client.PacketSendChanged += a =>
                        {

                        };
                        client.ConnectedChanged += () =>
                        {
                            Console.WriteLine("Connected!");
                        };

                        client.UpdateChanged += () =>
                        {
                            InvokeModule(m => m.TickUpdate());
                        };

                        client.PacketReceiveChanged += (p) =>
                        {
                            //Task.Run(() => System.Diagnostics.Debug.WriteLine(p.GetType().Name));

                            if (p.GetType() == typeof(ServerKeepAlivePacket))
                            {
                                client.SendPacket(new ClientKeepAlivePacket((p as ServerKeepAlivePacket).PingId));
                            }
                            else if (p.GetType() == typeof(ServerChatMessagePacket))
                            {
                                ServerChatMessagePacket chatpacket = p as ServerChatMessagePacket;

                                ChatQueue.Add(new ChatMessage(chatpacket.Message));
                                InvokeModule(m => m.ServerChat(chatpacket.Message));


                            }
                            else if (p is ServerChunkDataPacket)
                            {

                                ServerChunkDataPacket packet = p as ServerChunkDataPacket;
                                world[packet.ColumnX, packet.ColumnZ] = packet.Column;
                                InvokeModule(m => m.WorldUpdate(packet.ColumnX, packet.ColumnZ));

                            }
                            else if (p is ServerBlockChangePacket)
                            {
                                ServerBlockChangePacket block = p as ServerBlockChangePacket;
                                world.SetBlock(new Point3(block.Position.X, block.Position.Y, block.Position.Z), block.Block);
                                InvokeModule(m => m.WorldUpdate(block.Block));
                            }
                            else if (p is ServerSpawnEntityPacket)
                            {
                                ServerSpawnEntityPacket entity = p as ServerSpawnEntityPacket;

                                Entities[entity.NewEntity.ID] = entity.NewEntity;
                                InvokeModule(m => m.OnEntitySpawn(entity.NewEntity));

                            }
                            else if (p is ServerSpawnLivingEntityPacket)
                            {
                                ServerSpawnLivingEntityPacket entity = p as ServerSpawnLivingEntityPacket;

                                Entities[entity.NewEntity.ID] = entity.NewEntity;
                                InvokeModule(m => m.OnEntitySpawn(entity.NewEntity));
                            }
                            else if (p is ServerSpawnPlayerPacket)
                            {
                                ServerSpawnPlayerPacket player = p as ServerSpawnPlayerPacket;
                                string name = "";
                                if (OnlinePlayers.ContainsKey(player.UUID))
                                {
                                    name = OnlinePlayers[player.UUID];
                                }
                                Entity entity = new Entity(player.EntityID, EntityType.Player, player.Position, player.Yaw, player.Pitch, player.UUID, name);

                                Entities[player.EntityID] = entity;
                                InvokeModule(m => m.OnEntitySpawn(entity));
                            }
                            else if (p is ServerEntityTeleportPacket)
                            {
                                ServerEntityTeleportPacket teleport = p as ServerEntityTeleportPacket;

                                Entity entity = Entities[teleport.EntityID];
                                entity.Location = new Point3(teleport.X, teleport.Y, teleport.Z);
                                entity.Yaw = teleport.Yaw;
                                entity.Pitch = teleport.Pitch;
                                InvokeModule(m => m.OnEntityMove(entity));
                            }
                            else if (p is ServerEntityPositionPacket)
                            {
                                ServerEntityPositionPacket pos = p as ServerEntityPositionPacket;
                                if (Entities.ContainsKey(pos.EntityID))
                                {
                                    Entity entity = Entities[pos.EntityID];

                                    entity.Velocity = new Vector3(pos.DeltaX, pos.DeltaY, pos.DeltaZ);
                                    entity.Location.X += pos.DeltaX;
                                    entity.Location.Y += pos.DeltaY;
                                    entity.Location.Z += pos.DeltaZ;
                                    InvokeModule(m => m.OnEntityMove(entity));
                                }
                            }
                            else if (p is ServerEntityPositionAndRotationPacket)
                            {
                                ServerEntityPositionAndRotationPacket rot = p as ServerEntityPositionAndRotationPacket;
                                Entity entity = Entities[rot.EntityID];
                                entity.Velocity = new Vector3(rot.DeltaX, rot.DeltaY, rot.DeltaZ);
                                entity.Location.X += rot.DeltaX;
                                entity.Location.Y += rot.DeltaY;
                                entity.Location.Z += rot.DeltaZ;
                                InvokeModule(m => m.OnEntityMove(entity));
                            }
                            else if (p is ServerPlayerPositionAndLookPacket)
                            {
                                ServerPlayerPositionAndLookPacket pos = p as ServerPlayerPositionAndLookPacket;

                                double x = (pos.LocMask & 1 << 0) != 0 ? Position.X + pos.X : pos.X;
                                double y = (pos.LocMask & 1 << 1) != 0 ? Position.Y + pos.Y : pos.Y;
                                double z = (pos.LocMask & 1 << 2) != 0 ? Position.Z + pos.Z : pos.Z;

                                Position = new Point3(x, y, z);
                                Yaw = pos.Yaw;
                                Pitch = pos.Pitch;


                                client.SendPacket(new ClientTeleportConfirmPacket(pos.TeleportID));
                                InvokeModule(m => m.OnPositionRotation(Position, yaw, pitch));
                            }
                            else if (p is ServerPlayerInfoPacket)
                            {
                                ServerPlayerInfoPacket info = p as ServerPlayerInfoPacket;
                                foreach (var item in info.PlayerInfos.Values)
                                {
                                    if (item is PlayerJoin)
                                    {
                                        PlayerJoin playerJoin = item as PlayerJoin;
                                        OnlinePlayers[playerJoin.UUID] = playerJoin.Nickname;

                                        InvokeModule(m => m.OnPlayerJoin(item.UUID, playerJoin.Nickname));
                                    }


                                }
                            }
                            else if (p is ServerDestroyEntitiesPacket)
                            {
                                var destroys = p as ServerDestroyEntitiesPacket;
                                foreach (int id in destroys.Entities)
                                {
                                    Entities.Remove(id);
                                }
                            }
                            else if (p is ServerSpawnExperienceOrbPacket)
                            {
                                var exp = p as ServerSpawnExperienceOrbPacket;
                                Entities[exp.ID] = new Entity(exp.ID, EntityType.ExperienceOrb, new Point3());
                            }
                            else if (p is ServerSpawnPaintingPacket)
                            {
                                var paint = p as ServerSpawnPaintingPacket;
                                Entities[paint.ID] = new Entity(paint.ID, EntityType.Painting, new Point3());
                            }
                            else if (p is ServerPlayerHealthPacket)
                            {
                                var health = p as ServerPlayerHealthPacket;
                                Health = health.Health;
                                InvokeModule(m => m.OnHealthUpdate(health.Health, health.Food));
                            }

                        };
                        client.DisconnectChanged += (r, m) =>
                        {

                            // if (r == MinecraftLibrary.MinecraftProtocol.DisconnectReason.InGameKick)
                            ChatQueue?.Add(new ChatMessage("Вы были кинуты с сервера:"));
                            ChatQueue?.Add(new ChatMessage(m));
                            StatusLaunched = RunningStatus.None;
                            InvokeModule(x => x.Stop());

                        };
                        client.LoginSuccesChanged += () =>
                        {
                            Console.WriteLine("Login Sucess!!!");
                            StatusLaunched = RunningStatus.Launched;
                            InvokeModule(x => x.Start());
                        };
                        client.ReadPacketChanged += (s, i, d) =>
                        {
                            InvokeModule(m => m.ReadPacket(i, d));
                        };
                        if (client.Connect())
                        {

                        }




                    }
                    catch (Exception e)
                    {
                        ChatQueue.Add(new ChatMessage(e.ToString()));

                        StatusLaunched = RunningStatus.None;
                    }
                });
        }

        private void InvokeModule(Action<MinecraftModule> action)
        {

            foreach (var m in Modules.ToArray())
            {
                try
                {
                    action.Invoke(m);
                }
                catch (Exception e)
                {
                    Task.Run(() => System.Diagnostics.Debug.WriteLine("ERROROROORORORORO \n" + e));
                }
            }

        }

        public void RespawnPlayer()
        {
            if (Health == 0)
            {
                client.SendPacket(new ClientRequestPacket(MinecraftProtocol.Data.ClientRequest.RESPAWN));
            }
        }
        public void UpdatePosition(Point3 location, bool onground, bool updateProperty = true)
        {
            if (updateProperty)
            {
                Position = new Point3(location.X, location.Y, location.Z);
            }
            client.SendPacket(new ClientPlayerPositionPacket(location.X, location.Y, location.Z, onground));
        }
        public void UpdatePosition(Point3 pos, float yaw, float pitch, bool onground = true, bool updateProperty = true)
        {
            if (updateProperty)
            {
                Position = pos;
                Yaw = yaw;
                Pitch = pitch;
            }
            client.SendPacket(new ClientPlayerPositionAndRotationPacket(pos.X, pos.Y, pos.Z, yaw, pitch, onground));

        }
        public void UpdatePosition(Vector3 vector, bool onground)
        {
            Position += vector;
            //client.SendPacket(new ClientPlayerPositionPacket(Position.X, Position.Y, Position.Z, onground));
        }


        public void SendText(string msg)
        {
            try
            {

                client.SendPacket(new ClientChatMessagePacket(msg));
            }
            catch
            {

            }
        }




        /// <summary>
        /// Отключение от сервера
        /// </summary>
        public void Disconnect()
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Disconnect: " + nickname);
                client?.Dispose();
                StatusLaunched = RunningStatus.None;
                InvokeModule(x => x.Stop());
            }
            catch
            {

            }
        }
        /// <summary>
        /// Рестарт бота
        /// </summary>
        /// <returns>Результат запуска бота</returns>
        public void RestartClient()
        {
            if (StatusLaunched == RunningStatus.None) return;
            Disconnect();
            StartClient();
        }

        public void LookHead(float yaw, float pitch)
        {
            Yaw = yaw;
            Pitch = pitch;
            //client.SendPacket(new ClientPlayerRotationPacket(yaw, pitch, true));
        }
        public void LookHead(Point3 pos)
        {
            if (!pos.Equals(Position))
            {
                Vector3 vector = new Vector3(Position, pos);
                LookHead(vector);
            }
        }
        public void LookHead(Vector3 vector)
        {
            vector = vector.Normalize();
            float yaw = (float)((float)(Math.Atan2(vector.Z, vector.X) - Math.PI / 2) * 180 / Math.PI);
            float pitch = (float)(Math.Asin(-vector.Y) * 180 / Math.PI);
            LookHead(yaw, pitch);
        }

        public MinecraftModule FindModule(string name)
        {
            return Modules.FirstOrDefault(m => m.GetType().Name == name);
        }

        public void InvokeEvent(MinecraftModule sender,object parametr)
        {
            InvokeModule(m=>m.OnModuleEvent(sender.GetType().Name,parametr));
        }


        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        }
        public static int MCVer2ProtocolVersion(string MCVersion)
        {
            if (MCVersion.Contains('.'))
            {
                switch (MCVersion.Split(' ')[0].Trim())
                {
                    case "1.4.6":
                    case "1.4.7":
                        return 51;
                    case "1.5.1":
                        return 60;
                    case "1.5.2":
                        return 61;
                    case "1.6":
                    case "1.6.0":
                        return 72;
                    case "1.6.1":
                    case "1.6.2":
                    case "1.6.3":
                    case "1.6.4":
                        return 73;
                    case "1.7.2":
                    case "1.7.3":
                    case "1.7.4":
                    case "1.7.5":
                        return 4;
                    case "1.7.6":
                    case "1.7.7":
                    case "1.7.8":
                    case "1.7.9":
                    case "1.7.10":
                        return 5;
                    case "1.8":
                    case "1.8.0":
                    case "1.8.1":
                    case "1.8.2":
                    case "1.8.3":
                    case "1.8.4":
                    case "1.8.5":
                    case "1.8.6":
                    case "1.8.7":
                    case "1.8.8":
                    case "1.8.9":
                        return 47;
                    case "1.9":
                    case "1.9.0":
                        return 107;
                    case "1.9.1":
                        return 108;
                    case "1.9.2":
                        return 109;
                    case "1.9.3":
                    case "1.9.4":
                        return 110;
                    case "1.10":
                    case "1.10.0":
                    case "1.10.1":
                    case "1.10.2":
                        return 210;
                    case "1.11":
                    case "1.11.0":
                        return 315;
                    case "1.11.1":
                    case "1.11.2":
                        return 316;
                    case "1.12":
                    case "1.12.0":
                        return 335;
                    case "1.12.1":
                        return 338;
                    case "1.12.2":
                        return 340;
                    case "1.13":
                        return 393;
                    case "1.13.1":
                        return 401;
                    case "1.13.2":
                        return 404;
                    case "1.14":
                    case "1.14.0":
                        return 477;
                    case "1.14.1":
                        return 480;
                    case "1.14.2":
                        return 485;
                    case "1.14.3":
                        return 490;
                    case "1.14.4":
                        return 498;
                    case "1.15":
                    case "1.15.0":
                        return 573;
                    case "1.15.1":
                        return 575;
                    case "1.15.2":
                        return 578;
                    case "1.16":
                    case "1.16.0":
                        return 735;
                    case "1.16.1":
                        return 736;
                    case "1.16.2":
                        return 751;
                    case "1.16.3":
                        return 753;
                    case "1.16.4":
                    case "1.16.5":
                        return 754;
                    case "1.17":
                        return 755;
                    case "1.17.1":
                        return 756;
                    default:
                        return 0;
                }
            }
            else
            {
                try
                {
                    return Int32.Parse(MCVersion);
                }
                catch
                {
                    return 0;
                }
            }
        }
        public static long TwoIntToLong(int val1, int val2)
        {
            long res = val1;
            res = res << 32;
            res = res | (long)(uint)val2;
            return res;
        }
    }
    public enum MCVersion : int
    {
        [Description("1.12.2")]
        MC1_12_2 = 340,
        [Description("1.16.5")]
        MC1_16_5 = 754
    }
    public enum RunningStatus
    {
        None = 0,
        Initialization = 1,
        Launched = 2
    }
    public static class TypeExt
    {
        public static Type GetType(string fullname)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic)
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(t => t.FullName.Equals(fullname));
        }
    }
}
