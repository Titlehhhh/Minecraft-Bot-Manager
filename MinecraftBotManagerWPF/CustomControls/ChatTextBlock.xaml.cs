using Newtonsoft.Json.Linq;
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

namespace MinecraftBotManager.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для ChatTextBlock.xaml
    /// </summary>
    public partial class ChatTextBlock : UserControl
    {






        public ChatTextBlock()
        {
            InitializeComponent();
            
            
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine(Text.Text);
                Clipboard.SetText(Text.Text);
            }
            catch
            {

            }
        }
       
        
    }
}
