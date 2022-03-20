using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MinecraftBotManagerWPF
{
    public static class AddServicesHostBuilderExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<IDataService, DataService>();
                services.AddSingleton<IDialogService>((s) => new DialogService(s.GetRequiredService<MainWindow>()));
                
            });
            return hostBuilder;
        }
    }
}
