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
using GalaSoft.MvvmLight.Messaging;
using MinecraftBotManager.Messages;

namespace MinecraftBotManager.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddModuleWindow.xaml
    /// </summary>
    public partial class AddModuleWindow : Window
    {
        public AddModuleWindow()
        {
            InitializeComponent();
            
            Add.Click += Add_Click;
            Cancel.Click += Cancel_Click;

        }

        private void AddModuleWindow_Closed(object sender, EventArgs e)
        {
            
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Messenger.Default.Send<CloseAddModuleMessage>(new CloseAddModuleMessage());
            Close();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Type query = ListModules.SelectedItem as Type;
            if (query != null)
            {
                Messenger.Default.Send<CloseAddModuleMessage>(new CloseAddModuleMessage(query));
            }
            Close();
        }

    }
}
