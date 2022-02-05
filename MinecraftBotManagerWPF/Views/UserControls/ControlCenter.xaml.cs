using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using MaterialDesignThemes.Wpf;

namespace MinecraftBotManager.Views.UserControls
{
    /// <summary>
    /// Логика взаимодействия для ControlCenter.xaml
    /// </summary>
    public partial class ControlCenter : UserControl
    {
        public ControlCenter()
        {
            InitializeComponent();           

        }


        private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            string text = (string)e.DataObject.GetData(typeof(string));
            if (text == null || !text.All(IsNumber)) e.CancelCommand();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !e.Text.All(IsNumber);
        }
        private bool IsNumber(char c)
        {
            if (c >= '0' && c <= '9') return true;
            return false;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {

            //(RootTabControl.Items as ICollectionView).CollectionChanged += ControlCenter_CollectionChanged;
        }

        private void ControlCenter_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           // RootTabControl.SelectedIndex = RootTabControl.Items.Count - 1;
           // (RootTabControl.Items as ICollectionView).CollectionChanged -= ControlCenter_CollectionChanged;
        }

        private void GridChat_Loaded(object sender, RoutedEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null)
            {
                
            }
        }

        private void RootTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
