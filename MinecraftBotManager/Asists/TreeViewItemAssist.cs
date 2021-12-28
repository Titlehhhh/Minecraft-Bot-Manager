using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MinecraftBotManager.Asists
{
    public static class TreeViewItemAssist
    {

        public static bool GetIsInEditMode(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsInEditModeProperty);
        }

        public static void SetIsInEditMode(DependencyObject obj, bool value)
        {
            obj.SetValue(IsInEditModeProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsInEditMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.RegisterAttached("IsInEditMode", typeof(bool), typeof(TreeViewItem), new PropertyMetadata(false));


    }
}
