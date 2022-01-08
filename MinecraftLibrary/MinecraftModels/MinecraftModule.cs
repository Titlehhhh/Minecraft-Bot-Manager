using MinecraftLibrary.Data.Inventory;
using MinecraftLibrary.Data;
using MinecraftLibrary.MinecraftProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MinecraftLibrary.Interfaces;
using MinecraftLibrary.Geometri;

namespace MinecraftLibrary.MinecraftModels
{
    public abstract class MinecraftModule : INotifyPropertyChanged
    {
        [Browsable(false)]
        public BotObject MainBot => mainBot;

        private BotObject mainBot;
        public IMainViewModelController MainViewModel { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MinecraftModule(BotObject mainBot, IMainViewModelController controller)
        {
            this.mainBot = mainBot;
            this.MainViewModel = controller;
            //this.dataService = dataService;
        }
        public virtual void UnLoad() { }
        public virtual void Start() { }
        public virtual void Stop() { }

        private bool autostart;
        [Browsable(false)]
        public bool AutoStart
        {
            get { return autostart; }
            set
            {
                autostart = value;
                RaisePropertyChanged();
            }
        }

        private bool isRun;
        [Browsable(false)]
        public bool IsEnabled
        {
            get
            {
                return isRun;
            }
            set
            {
                isRun = value;
                RaisePropertyChanged();
            }
        }
        public virtual void ReadPacket(int id, byte[] data) { }
        public virtual void WorldUpdate(int chunkX,int chunkZ) { }
        public virtual void WorldUpdate(Block block) { }
        public virtual void OnBlockBreakAnimation(Entity entity, Location location, byte stage) { }
        public virtual void OnEntityAnimation(Entity entity, byte animation) { }
        public virtual void ServerChat(string json) { }
        public virtual void ServerChat(string message, string json) { }
        public virtual void OnDisconnect(DisconnectReason reason, string message) { }
        public virtual void OnTimeUpdate(long WorldAge, long TimeOfDay) { }
        public virtual void OnEntityMove(Entity entity) { }
        public virtual void OnEntitySpawn(Entity entity) { }
        public virtual void OnEntityDespawn(Entity entity) { }
        public virtual void OnHeldItemChange(byte slot) { }
        public virtual void OnHealthUpdate(float health, int food) { }
        public virtual void OnExplosion(Location explode, float strength, int recordcount) { }
        public virtual void OnSetExperience(float Experiencebar, int Level, int TotalExperience) { }
        public virtual void OnGamemodeUpdate(string playername, Guid uuid, int gamemode) { }
        public virtual void OnLatencyUpdate(string playername, Guid uuid, int latency) { }
        public virtual void OnLatencyUpdate(Entity entity, string playername, Guid uuid, int latency) { }
        public virtual void OnMapData(int mapid, byte scale, bool trackingposition, bool locked, int iconcount) { }
        public virtual void OnTradeList(int windowID, List<VillagerTrade> trades, MinecraftLibrary.Data.Inventory.VillagerInfo villagerInfo) { }
        public virtual void OnTitle(int action, string titletext, string subtitletext, string actionbartext, int fadein, int stay, int fadeout, string json) { }
        public virtual void OnEntityEquipment(Entity entity, int slot, Item item) { }
        public virtual void OnEntityEffect(Entity entity, Effects effect, int amplifier, int duration, byte flags) { }
        public virtual void OnScoreboardObjective(string objectivename, byte mode, string objectivevalue, int type, string json) { }
        public virtual void OnUpdateScore(string entityname, byte action, string objectivename, int value) { }
        public virtual void OnInventoryUpdate(int inventoryId) { }
        public virtual void OnInventoryOpen(int inventoryId) { }
        public virtual void OnInventoryClose(int inventoryId) { }
        public virtual void OnPlayerJoin(Guid uuid, string name) { }
        public virtual void OnPlayerLeave(Guid uuid, string name) { }
        public virtual void OnDeath() { }
        public virtual void OnRespawn() { }
        public virtual void OnEntityHealth(Entity entity, float health) { }
        public virtual void OnEntityMetadata(Entity entity, Dictionary<int, object> metadata) { }
        public virtual void OnPlayerStatus(byte statusId) { }
        public virtual void OnPositionRotation(Location pos, float yaw,float pitch) { }

        public void SendText(string msg)
        {
            MainBot.SendText(msg);
        }
        public void LookHead(float yaw,float pitch)
        {
            MainBot.LookHead(yaw, pitch);
        }
        public void LookHead(Vector3 pos)
        {
            MainBot.LookHead(pos);
        }
        public void LookHead(Location vector)
        {
            mainBot.LookHead(vector);

        }
        public void ChatAdd(string text,bool isjson = true)
        {
            MainBot.ChatQueue.Add(new ChatMessage(text, isjson));
        }

    }
}
