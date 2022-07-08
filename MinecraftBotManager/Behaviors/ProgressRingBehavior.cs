using Microsoft.UI.Xaml.Controls;
using Microsoft.Xaml.Interactivity;
using MinecraftBotManager.ViewModels;

namespace MinecraftBotManager.Behaviors
{
    public class ProgressRingBehavior : Behavior<ProgressRing>
    {
        private Status status;

        public Status Status
        {
            get { return status; }
            set
            {
                status = value;
                if (value == Status.Loading)
                {
                    AssociatedObject.Visibility = Microsoft.UI.Xaml.Visibility.Visible;
                }
                else
                {
                    AssociatedObject.Visibility = Microsoft.UI.Xaml.Visibility.Collapsed;
                }
            }
        }

    }

}
