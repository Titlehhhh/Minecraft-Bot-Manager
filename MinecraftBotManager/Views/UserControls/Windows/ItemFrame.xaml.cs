
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SharpDX;
using SharpDX.Direct3D9;
using System.Windows.Interop;
using System.Windows.Media.Media3D;

namespace MinecraftBotManager.Views.UserControls.Windows
{
    /// <summary>
    /// Логика взаимодействия для ItemFrame.xaml
    /// </summary>
    public partial class ItemFrame : UserControl
    {


        public string BackgoundIcon
        {
            get { return (string)GetValue(BackgoundIconProperty); }
            set { SetValue(BackgoundIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgoundIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgoundIconProperty =
            DependencyProperty.Register("BackgoundIcon", typeof(string), typeof(ItemFrame), new PropertyMetadata(""));




        public object ContentIcon
        {
            get { return (object)GetValue(ContentIconProperty); }
            set { SetValue(ContentIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ContentIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ContentIconProperty =
            DependencyProperty.Register("ContentIcon", typeof(object), typeof(ItemFrame), new PropertyMetadata(null));



        Surface target;
        public ItemFrame()
        {
            InitializeComponent();
            


        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            
        }
    }
}
