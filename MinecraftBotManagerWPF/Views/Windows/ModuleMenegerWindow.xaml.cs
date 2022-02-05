using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignExtensions.Controls;
using ICSharpCode.AvalonEdit.Document;
using MaterialDesignThemes.Wpf;
using GalaSoft.MvvmLight.Messaging;

namespace MinecraftBotManager.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для ModuleMenegerWindow.xaml
    /// </summary>
    public partial class ModuleMenegerWindow : MaterialWindow
    {
        CreateElementWindow modalWindow;
        public static Guid Token = Guid.NewGuid();
        public ModuleMenegerWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<NotificationMessageAction>(this,Token, ShowDialog);
        }
        private void ShowDialog(NotificationMessageAction message)
        {
            modalWindow = new CreateElementWindow();
            modalWindow.ShowDialog();
        }
    }
    public class LanguageItem : DependencyObject
    {
        public PackIconKind Icon
        {
            get { return (PackIconKind)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(PackIconKind), typeof(LanguageItem), new PropertyMetadata(PackIconKind.Abacus));



        public string Name
        {
            get { return (string)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.Register("Name", typeof(string), typeof(LanguageItem), new PropertyMetadata(""));




    }


}
