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


        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Message.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(CheckStatusControl), new PropertyMetadata(""));




        public StatusCheck State
        {
            get { return (StatusCheck)GetValue(StateProperty); }
            set
            {
                SetValue(StateProperty, value);
                OkIcon.Visibility = ErrorIcon.Visibility = ProgressBar.Visibility = Visibility.Hidden;
                switch (value)
                {
                    case StatusCheck.Init:
                        ProgressBar.Visibility = Visibility.Visible;
                        break;
                    case StatusCheck.Ok:
                        OkIcon.Visibility = Visibility.Visible;
                        break;
                    case StatusCheck.Error:
                        ErrorIcon.Visibility = Visibility.Visible;
                        break;
                }

            }
        }

        // Using a DependencyProperty as the backing store for State.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register("State", typeof(StatusCheck), typeof(CheckStatusControl), new PropertyMetadata(StatusCheck.Ok));





        public CheckStatusControl()
        {
            DataContext = this;
            InitializeComponent();
        }
    }
}
