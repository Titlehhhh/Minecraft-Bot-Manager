using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MinecraftBotManagerWPF
{
    public static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<BotViewModelsStorage>();
            });
            return hostBuilder;
        }
    }
}
