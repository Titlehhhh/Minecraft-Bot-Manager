using System.Windows;
using System.Windows.Controls;

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
