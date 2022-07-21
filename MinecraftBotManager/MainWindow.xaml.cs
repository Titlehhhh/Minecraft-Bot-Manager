using Microsoft.UI.Xaml;
using MinecraftBotManager.ViewModels;
using MinecraftBotManager.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MinecraftBotManager
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainViewModel ViewModel { get; private set; }

        public MainWindow()
        {
            ViewModel = App.GetService<MainViewModel>();
            //ViewModel = null;
            this.InitializeComponent();

            ExtendsContentIntoTitleBar = true;
            SetTitleBar(TitleBar);
            NavigationFrame.Navigate(typeof(HomePage));

        }

        private void MainWindow_Closed(object sender, WindowEventArgs args)
        {
            var command = ViewModel.ClosedCommand;
            if (command.CanExecute(null))
                command.Execute(null);
        }
    }
}
