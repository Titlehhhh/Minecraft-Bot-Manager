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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MinecraftBotManagerWPF.Enums;
using MinecraftBotManagerWPF.ViewModels;

namespace MinecraftBotManagerWPF.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для CheckStatusControl.xaml
    /// </summary>
    public partial class CheckStatusControl : UserControl
    {
        public CheckStatusControl()
        {
            InitializeComponent();
            this.DataContextChanged += CheckStatusControl_DataContextChanged;
        }

        private void CheckStatusControl_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //Task.Run(() => Dispatcher.Invoke(() => MessageBox.Show("sd: " + this.DataContext?.GetType().Name)));
        }
    }
}
