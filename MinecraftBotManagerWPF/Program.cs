using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MinecraftBotManagerWPF;
using System;
using System.Windows;

class Program
{
    [STAThread]
    public static void Main2()
    {
        var host = Host.CreateDefaultBuilder()
                .AddServices()
                .AddViewModels()
                .AddViews()
                .ConfigureServices(AddApp)
                .Build();



        var botRepository = host.Services.GetRequiredService<IBotRepository>();
        botRepository.InizializeAsync();

        host.StartAsync();

        //var app = host.Services.GetRequiredService<App>();
        //app.InitializeComponent();



        Window window = host.Services.GetRequiredService<MainWindow>();
        window.DataContext = host.Services.GetRequiredService<MainViewModel>();
        window.Show();

        Application.Current.MainWindow = window;
        //app.Run();
    }
    static void AddApp(IServiceCollection services)
    {
        // services.AddSingleton<App>();
    }
}



