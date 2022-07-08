using Microsoft.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using MinecraftBotManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftBotManager.Behaviors
{
    public class FontIconBehavior : Behavior<FontIcon>
    {
        private Status status;

        public Status Status
        {
            get => status;
            set
            {
                status = value;
                AssociatedObject.Visibility = Microsoft.UI.Xaml.Visibility.Visible;

                switch (value)
                {

                    case Status.Ok:
                        AssociatedObject.Glyph = "\uE739";
                        AssociatedObject.Foreground = App.Current.Resources[];
                        break;
                    case Status.Error:
                        AssociatedObject.Glyph = "\uE783";
                        break;
                    case Status.Warning:
                        AssociatedObject.Glyph = "\uE7BA";
                        break;
                    case Status.Loading:
                        AssociatedObject.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                        break;

                }
            }
        }

    }

}
