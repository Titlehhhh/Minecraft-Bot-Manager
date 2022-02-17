using MinecraftBotManagerWPF.ViewModels;
using MinecraftBotManagerWPF.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            start.DataContext = new StartupVM(() =>
            {
                
                MainWindow main = new MainWindow();
                main.DataContext = new MainViewModel();

                this.MainWindow = main;
                main.Show();
                start.Close();
            });
            this.MainWindow = start;
            start.Show();

            base.OnStartup(e);
        }
    }
}
