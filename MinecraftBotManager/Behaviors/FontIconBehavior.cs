using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Microsoft.Xaml.Interactivity;
using MinecraftBotManager.ViewModels;

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
                        AssociatedObject.Glyph = "\uE73E";
                        AssociatedObject.Foreground = (SolidColorBrush)App.Current.Resources["OkColor"];
                        break;
                    case Status.Error:
                        AssociatedObject.Glyph = "\uE783";
                        AssociatedObject.Foreground = (SolidColorBrush)App.Current.Resources["ErrorColor"];
                        break;
                    case Status.Warning:
                        AssociatedObject.Glyph = "\uE7BA";
                        AssociatedObject.Foreground = (SolidColorBrush)App.Current.Resources["WarnColor"];
                        break;
                    case Status.Loading:
                        AssociatedObject.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                        break;

                }
            }
        }

    }

}
