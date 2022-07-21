using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Markup;
using MinecraftBotManager.ViewModels;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MinecraftBotManager.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomeViewModel ViewModel { get; private set; }

        public HomePage()
        {
            try
            {
                ViewModel = App.GetService<HomeViewModel>();
                this.InitializeComponent();
            }
            catch (Exception gg)
            {
                System.Diagnostics.Trace.WriteLine(gg);
            }
        }

        private void host_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }

    [MarkupExtensionReturnType(ReturnType = typeof(Array))]
    public sealed class EnumValuesExtension : MarkupExtension
    {
        private Type enumType;

        public Type EnumType
        {
            get { return enumType; }
            set { enumType = value; }
        }

        protected override object ProvideValue()
        {
            return Enum.GetNames(EnumType);
        }
    }


}
