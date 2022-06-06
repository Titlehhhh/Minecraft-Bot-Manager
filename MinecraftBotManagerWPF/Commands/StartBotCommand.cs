using McProtoNet.Utils;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace MinecraftBotManagerWPF
{
    internal class StartBotCommand : AsyncCommandBase
    {

        private readonly BotViewModel _botViewModel;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public StartBotCommand(BotViewModel botViewModel, IServiceScopeFactory serviceScopeFactory)
        {
            _botViewModel = botViewModel;
            _serviceScopeFactory = serviceScopeFactory;
        }

        public async override Task ExecuteAsync(object parameter)
        {
            await Task.Run(async () =>
             {
                 using (var scope = _serviceScopeFactory.CreateScope())
                 {
                     IMinecraftBotRunner _runner =
                        new MinecraftBotRunner(_botViewModel,
                        scope.ServiceProvider.GetRequiredService<IBotRepository>(),
                        scope.ServiceProvider.GetRequiredService<IAuthService>(),
                        scope.ServiceProvider.GetRequiredService<IServerResolver>());


                     await _runner.RunBotAsync();
                 }
             });



        }

    }
}
