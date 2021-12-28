using MaterialDesignExtensions.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using System.Threading;
using GalaSoft.MvvmLight.Messaging;
using MinecraftBotManager.Messages;
using System.Diagnostics;
using System.Windows.Threading;


namespace MinecraftBotManager.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class MainWindow : MaterialWindow
    {
        private AddModuleWindow modalWindow;
        private ProxyListWindow proxyListWindow;
        private ModuleMenegerWindow moduleMeneger;

        Random rand = new Random();
        Stopwatch stopwatch;
        long frameCounter = 0;
        GlyphTypeface glyphTypeface;
        double renderingEmSize, advanceWidth, advanceHeight;
        Point baselineOrigin;

        public MainWindow()
        {
            InitializeComponent();
            NotifiPopup.Opened += NotifiPopup_Opened;
            Messenger.Default.Register<ShowAddElementMessage>(this, async msg =>
             {
                 await Task.Run(() => Dispatcher.Invoke(() => (modalWindow = new AddModuleWindow()).ShowDialog()));
             });
            Closed += MainWindow_Closed;

           

        }



        private void MainWindow_Closed(object sender, EventArgs e)
        {
            Messenger.Default.Unregister(this);
            proxyListWindow?.Close();
            moduleMeneger?.Close();
        }

        private void NotifiPopup_Opened(object sender, EventArgs e)
        {

        }

        private void NotifiPopup_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ProxyListButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<ProxyListWindow>().Any())
                (proxyListWindow = new ProxyListWindow()).Show();
        }

        private void ModuleWindowButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Application.Current.Windows.OfType<ModuleMenegerWindow>().Any())
                (moduleMeneger = new ModuleMenegerWindow()).Show();
        }

        private void NotificationsButton_Click(object sender, RoutedEventArgs e)
        {


        }

        private void TaskButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
