using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace MinecraftBotManager.Behaviors
{
    public class TabControlUcWrapperBehavior : Behavior<UIElement>
    {
        private TabControl AssociatedTabControl { get { return (TabControl)AssociatedObject; } }

        protected override void OnAttached()
        {
            ((INotifyCollectionChanged)AssociatedTabControl.Items).CollectionChanged += TabControlUcWrapperBehavior_CollectionChanged;
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            ((INotifyCollectionChanged)AssociatedTabControl.Items).CollectionChanged -= TabControlUcWrapperBehavior_CollectionChanged;
            base.OnDetaching();
        }

        void TabControlUcWrapperBehavior_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action != NotifyCollectionChangedAction.Add)
                return;

            foreach (var newItem in e.NewItems)
            {
                var ti = AssociatedTabControl.ItemContainerGenerator.ContainerFromItem(newItem) as TabItem;

                if (ti != null && !(ti.Content is UserControl))
                    ti.Content = new UserControl { Content = ti.Content };
            }
        }
    }
}
