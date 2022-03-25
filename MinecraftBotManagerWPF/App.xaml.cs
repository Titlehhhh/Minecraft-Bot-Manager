using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace MinecraftBotManagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost host;

        //public static  MinecraftBotFactory BotFactory { get; } = new MinecraftBotFactory();

        private StartupWindow start;

        public App()
        {
            start = new StartupWindow();
            start.Show();
            host = Host.CreateDefaultBuilder()
                .AddServices()
                .AddViewModels()
                .AddViews()
                .Build();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await host.StopAsync();

            Window window = host.Services.GetRequiredService<MainWindow>();
            window.DataContext = host.Services.GetRequiredService<MainViewModel>();
            window.Show();
            start.Close();
            start = null;

            Application.Current.MainWindow = window;
            //this.MainWindow = start;
            //start.DataContext = new StartupVM(() =>
            //{
            //    MainWindow main = new MainWindow();
            //    main.DataContext = new MainViewModel(new DialogService(main), new DataService());
            //    main.Show();
            //    this.MainWindow = main;

            //    start.Close();
            //});
        }
        protected override void OnExit(ExitEventArgs e)
        {
            host.StopAsync();
            host.Dispose();

            base.OnExit(e);
        }
    }
}
