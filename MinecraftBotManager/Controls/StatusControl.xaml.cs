using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using MinecraftBotManager.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

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
