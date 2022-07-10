using McProtoNet.Utils;
using MinecraftBotManager.Api.Models;
using MinecraftBotManager.Data;
using MinecraftBotManager.ViewModels;
using System.Threading.Tasks;

namespace MinecraftBotManager.Helpers
{
    public class BotRunService
    {
        private readonly BotRecord options;
        private readonly BotViewModel viewModel;

        public BotRunService (BotRecord options,BotViewModel viewModel)
        {
            this.options = options;
            this.viewModel = viewModel;
        }



        public async Task StartBot()
        {
            
        }
    }
}
