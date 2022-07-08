using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MinecraftBotManager.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MinecraftBotManager.Controls
{
    public sealed partial class StatusControl : UserControl
    {


        public StatusVM StatusContext
        {
            get { return (StatusVM)GetValue(StatusContextProperty); }
            set { SetValue(StatusContextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StatusContext.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StatusContextProperty =
            DependencyProperty.Register("StatusContext", typeof(StatusVM), typeof(StatusControl), new PropertyMetadata(null));




        public StatusControl()
        {
            this.InitializeComponent();
        }
    }
}
