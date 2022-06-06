using McProtoNet.Utils;
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
