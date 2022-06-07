using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManagerWinUI.HostBuilder
{
    public static class AddServices
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<IBotRepository, BotRepository>();
                services.AddSingleton<IDataService, DataService>();
                services.AddSingleton<IDialogService>((s) => new DialogService(s.GetRequiredService<MainWindow>()));
                services.AddScoped<IAuthService, AuthService>();
                services.AddTransient<IServerResolver, ServerResolver>();
                services.AddTransient<IBotVMFactory, BotVMFactory>();
                // services.AddSingleton<IServiceScopeFactory,scope>
            });
            return hostBuilder;
        }
    }
}
