
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Linq;
using System.Windows.Data;
using System.Collections.Specialized;

namespace MinecraftBotManager.Behaviors
{
    public class TabControlBehaivior : Behavior<TabControl>
    {
        protected override void OnAttached()
        {
            INotifyCollectionChanged gg = AssociatedObject.Items;
            gg.CollectionChanged += Gg_CollectionChanged;
        }

        private void Gg_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

        }

        protected override void OnDetaching()
        {

            INotifyCollectionChanged gg = AssociatedObject.Items;
            gg.CollectionChanged -= Gg_CollectionChanged;

        }
    }
}
