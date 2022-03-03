using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MinecraftBotManagerWPF.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для IPAddressControl.xaml
    /// </summary>
    public partial class IPAddressControl : UserControl, IDataErrorInfo
    {


        public string IPAddress
        {
            get { return (string)GetValue(IPAddressProperty); }
            set { SetValue(IPAddressProperty, value); }
        }

        public string Error => throw new NotImplementedException();

        public string this[string columnName] => Validation.GetHasError(this) ? "Этот IP адрес неверный" : null;

        // Using a DependencyProperty as the backing store for IPAddress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IPAddressProperty =
            DependencyProperty.Register("IPAddress", typeof(string), typeof(IPAddressControl), new PropertyMetadata(""));




        public IPAddressControl()
        {
            InitializeComponent();
        }
    }
}
