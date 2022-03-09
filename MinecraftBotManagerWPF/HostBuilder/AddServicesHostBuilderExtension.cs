using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MinecraftBotManagerWPF.Interfaces;
using MinecraftBotManagerWPF.Services;
using MinecraftBotManagerWPF.Views.Windows;

namespace MinecraftBotManagerWPF.HostBuilder
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
