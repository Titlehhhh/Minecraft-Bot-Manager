using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;

namespace MinecraftBotManagerWPF
{
    public static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<BotViewModelsStorage>((s) =>
                {
                    return new BotViewModelsStorage(s.GetRequiredService<IDataService>()
                        .BotRepository.GetAllBots()
                        .Select(b => new BotViewModel(b, s.GetRequiredService<IDataService>().BotRepository)));
                });
            });
            return hostBuilder;
        }
    }
}
