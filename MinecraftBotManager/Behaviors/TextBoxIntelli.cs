using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Globalization;

namespace MinecraftBotManager.Behaviors
{
    public class TextBoxIntelli : Behavior<TextBox>
    {


        public Popup Popup
        {
            get { return (Popup)GetValue(PopupProperty); }
            set { SetValue(PopupProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Popup.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PopupProperty =
            DependencyProperty.Register("Popup", typeof(Popup), typeof(TextBoxIntelli), new PropertyMetadata(null));


        protected override void OnAttached()
        {
            AssociatedObject.TextChanged += AssociatedObject_TextChanged;
            Popup.PlacementTarget = AssociatedObject;
            Popup.StaysOpen = false;
        }

        private void AssociatedObject_TextChanged(object sender, TextChangedEventArgs e)
        {
            Popup.IsOpen = false;
            Console.WriteLine(AssociatedObject.Text);
            Popup.HorizontalOffset =Caltulate(AssociatedObject.Text, AssociatedObject).Width;
            Console.WriteLine();
            Popup.IsOpen = true;
        }
        public static Size Caltulate(string msg, TextBox textBox)
        {
            var formatted = new FormattedText(
                msg,
                CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(textBox.FontFamily, textBox.FontStyle, textBox.FontWeight, textBox.FontStretch),
                textBox.FontSize,
                Brushes.Black,
                new NumberSubstitution(),
                1
                );
            return new Size(formatted.Width, formatted.Height);
        }
    }

}
