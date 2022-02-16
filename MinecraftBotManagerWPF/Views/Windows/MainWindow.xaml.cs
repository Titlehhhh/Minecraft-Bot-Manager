using MaterialDesignExtensions.Controls;
using MaterialDesignThemes.Wpf;
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

namespace MinecraftBotManagerWPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            if (WindowState == WindowState.Maximized)
            {
                (ResizeButton.Content as PackIcon).Kind = PackIconKind.WindowRestore;
            }
            else if (WindowState == WindowState.Normal)
            {
                (ResizeButton.Content as PackIcon).Kind = PackIconKind.WindowMaximize;
            }
            this.StateChanged += MainWindow_StateChanged;
        }

        private void MainWindow_StateChanged(object? sender, EventArgs e)
        {
            if (WindowState == WindowState.Maximized)
            {
                (ResizeButton.Content as PackIcon).Kind = PackIconKind.WindowRestore;
            }
            else if (WindowState == WindowState.Normal)
            {
                (ResizeButton.Content as PackIcon).Kind = PackIconKind.WindowMaximize;
            }
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ResizeButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                // (button.Content as PackIcon).Kind = PackIconKind.WindowMaximize;
            }
            else if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
                //(button.Content as PackIcon).Kind = PackIconKind.WindowRestore;
            }
        }


        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
