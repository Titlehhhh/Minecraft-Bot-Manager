using System;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    public class BotVMHelper : IBotVMHelper
    {
        private readonly BotViewModel _botViewModel;
        private readonly IMinecraftBotRunner _runner;

        public BotVMHelper(BotViewModel botViewModel)
        {
            _botViewModel = botViewModel;
        }


        public Task RestartBotAsync()
        {
            throw new NotImplementedException();
        }

        public async Task StartBotAsync()
        {
            await _runner.PreparingAsync();

            if (!await _runner.AuthenticationAsync())
                return;
            if (!await _runner.ConfigureProxyAsync())
                return;
            if (!await _runner.ConfigureServerAsync())
                return;
            if (!await _runner.RunBotAsync())
                return;
        }

        public Task StopBotAsync()
        {
            throw new NotImplementedException();
        }
    }
}
