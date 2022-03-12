using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MinecraftBotManagerWPF
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
