using Microsoft.Xaml.Behaviors;
using System;
using System.Windows.Controls;

namespace MinecraftBotManagerWPF
{
    public class TextBoxPortBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.PreviewTextInput += AssociatedObject_PreviewTextInput;
        }
        protected override void OnDetaching()
        {
            AssociatedObject.PreviewTextInput -= AssociatedObject_PreviewTextInput;
        }
        private void AssociatedObject_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            try
            {
                //string text = AssociatedObject.Text + e.Text;
                // System.Diagnostics.Debug.WriteLine(text);
                //Convert.ToUInt16(text);
            }
            catch (Exception)
            {
                e.Handled = true;
            }
        }
    }
}
