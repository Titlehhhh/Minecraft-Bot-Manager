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


        public string Json
        {
            get { return (string)GetValue(JsonProperty); }
            set
            {
                SetValue(JsonProperty, value);
                Render();
            }
        }






        public bool IsNeed
        {
            get { return (bool)GetValue(IsNeedProperty); }
            set
            {
                SetValue(IsNeedProperty, value);
                if (value)
                {
                    CompositionTarget.Rendering += CompositionTarget_Rendering;
                }
                else
                {
                    CompositionTarget.Rendering -= CompositionTarget_Rendering;
                }
                IsEvent = value;
            }
        }

        private bool IsEvent;

        // Using a DependencyProperty as the backing store for IsNeed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsNeedProperty =
            DependencyProperty.Register("IsNeed", typeof(bool), typeof(ChatTextBlock), new PropertyMetadata(false));






        // Using a DependencyProperty as the backing store for Json.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JsonProperty =
            DependencyProperty.Register("Json", typeof(string), typeof(ChatTextBlock), new PropertyMetadata(""));


        public ChatTextBlock()
        {
            InitializeComponent();
            Render();
            CompositionTarget.Rendering += CompositionTarget_Rendering;
            IsEvent = true;
            Unloaded += ChatTextBlock_Unloaded;
        }

        private void ChatTextBlock_Unloaded(object sender, RoutedEventArgs e)
        {
           
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
            IsEvent = false;
        }

        private void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (IsNeed)
                Test.UnicodeString = GenerateRandomString(10);


        }
        Random rand = new Random();
        string GenerateRandomString(int length)
        {
            var chars = new char[length];
            for (int i = 0; i < chars.Length; ++i)
            {
                chars[i] = (char)rand.Next('A', 'Z' - 1);
            }

            return new string(chars);
        }
        private void Render()
        {

        }
    }
}
