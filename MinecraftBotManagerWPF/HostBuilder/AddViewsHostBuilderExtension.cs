using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MinecraftBotManagerWPF.ViewModels;
using MinecraftBotManagerWPF.Views.Windows;
using MinecraftBotManagerWPF.Interfaces;
using MinecraftBotManagerWPF.Services;

namespace MinecraftBotManagerWPF.HostBuilder
{
    public static class AddViewsHostBuilderExtension
    {
        public static IHostBuilder AddViews(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>((s) =>
                {
                    MainWindow mainWindow = new MainWindow();
                    return mainWindow;
                });
            });
            return hostBuilder;
        }
    }
}
