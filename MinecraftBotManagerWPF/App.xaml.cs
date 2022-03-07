using MinecraftBotManagerWPF.Services;
using MinecraftBotManagerWPF.ViewModels;
using MinecraftBotManagerWPF.Views.Windows;
using System.Windows;

namespace MinecraftBotManagerWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            StartupWindow start = new StartupWindow();
            start.Show();
            this.MainWindow = start;
            start.DataContext = new StartupVM(() =>
            {
                MainWindow main = new MainWindow();
                main.DataContext = new MainViewModel(new DialogService(main),new DataService());
                main.Show();
                this.MainWindow = main;

                start.Close();
            });
        }
    }
}
