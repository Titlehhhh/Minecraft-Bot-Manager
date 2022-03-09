using MaterialDesignThemes.Wpf;
using MinecraftBotManagerWPF.ViewModels;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MinecraftBotManagerWPF.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            System.Diagnostics.Debug.WriteLine("MainwunCreate");
            InitializeComponent();
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                DataContext = new DesignMainVM();
            }
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
