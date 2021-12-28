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
using MaterialDesignExtensions.Controls;
using MinecraftBotManager.ViewModel;

namespace MinecraftBotManager.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ProxyListWindow.xaml
    /// </summary>
    public partial class ProxyListWindow : MaterialWindow
    {
        
        public ProxyListWindow()
        {
            InitializeComponent();
            Loaded += ProxyListWindow_Loaded;
        }

        private void ProxyListWindow_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
