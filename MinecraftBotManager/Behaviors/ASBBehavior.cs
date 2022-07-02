using Microsoft.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Behaviors
{
    public class ASBBehavior : Behavior<AutoSuggestBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            
        }
    }
    
}
