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
using System.Runtime.CompilerServices;
using System.IO;
using MinecraftBotManager.CustomControls.FileProvider;
using System.Collections.ObjectModel;

namespace MinecraftBotManager.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для SolutionTreeView.xaml
    /// </summary>
    public partial class SolutionTreeView : UserControl
    {






        public SolutionTreeView()
        {
            InitializeComponent();

        }

        private void TreeViewFiles_MouseDown(object sender, MouseButtonEventArgs e)
        {

            TreeViewItem item = VisualSearch(e.OriginalSource as DependencyObject);
            if (item != null)
            {
                item.Focus();
                item.IsSelected = true;
                e.Handled = true;
            }

        }
        static TreeViewItem VisualSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);
            return source as TreeViewItem;
        }

        private void TreeViewFiles_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if(sender is TreeView && !e.Handled)
            {
                e.Handled = true;
                var eventargs = new MouseWheelEventArgs(e.MouseDevice,e.Timestamp,e.Delta);
                eventargs.RoutedEvent = UIElement.MouseWheelEvent;
                eventargs.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventargs);
            }
        }

        private void TreeViewFiles_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem item = sender as TreeViewItem;
            if (item != null)
            {
                if (!item.HasItems && e.ClickCount>1)
                {
                    e.Handled = true;
                }
            }
        }
    }
}
