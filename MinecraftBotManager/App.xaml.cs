using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.UI.Xaml;
using MinecraftBotManager.ViewModels;
using MinecraftBotManager.Data;
using MinecraftBotManager.Services;
using System.Reflection;
using System;
using MinecraftBotManager.Contracts.Services;

namespace MinecraftBotManager
{

    public partial class App : Application
    {

        public App()
        {

            AppDomain.CurrentDomain.FirstChanceException += (s, e) =>
            {
                System.Diagnostics.Trace.WriteLine("domainEx: "+e.Exception.ToString());
            };
            UnhandledException += App_UnhandledException;

            this.InitializeComponent();
        }

        private void App_UnhandledException(object sender, Microsoft.UI.Xaml.UnhandledExceptionEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine("appEx:"+e.Exception.ToString());
        }

        private static readonly IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<IBotRepository, BotRepository>();
                services.AddSingleton<ISerializationService, JsonSerializationService>();


            }).Build();

        public static T GetService<T>()
        {
            return host.Services.GetRequiredService<T>();
        }


        protected override async void OnLaunched(Microsoft.UI.Xaml.LaunchActivatedEventArgs args)
        {

            IBotRepository botRepository = App.GetService<IBotRepository>();
            await botRepository.InizializeAsync();
            host.Start();

            m_window = new MainWindow();

            m_window.Activate();
        }



        private Window m_window;
    }
}
