using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using MinecraftBotManager.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MinecraftBotManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; private set; }

        public MainPage()
        {
            ViewModel = App.GetService<MainViewModel>();
            this.InitializeComponent();
        }

        private void host_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
