using MinecraftLibrary.MinecraftModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using MinecraftLibrary.Interfaces;
using MinecraftLibrary.Data;

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
    public class TestModule2 : MinecraftModule
    {
        private int Target;
        public TestModule2(BotObject mainBot, IMainViewModelController controller) : base(mainBot, controller)
        {

        }
        public override void ServerChat(string json)
        {

        }
        public override void OnEntityMove(Entity entity)
        {

            if (entity.Type == EntityType.Player)
            {
                LookHead(entity.Location);
            }
        }
        public override void OnEntitySpawn(Entity entity)
        {
            if (entity.CustomName == "Title_")
            {
                Target = entity.ID;
            }
        }
    }
}
