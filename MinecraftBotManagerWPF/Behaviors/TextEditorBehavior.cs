using ICSharpCode.AvalonEdit;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace MinecraftBotManager.Behaviors
{
    public class TextEditorBehavior : Behavior<TextEditor>
    {
        public Brush SelectionBrush { get; set; }
        protected override void OnAttached()
        {
            AssociatedObject.TextArea.SelectionBrush = SelectionBrush;
        }
        protected override void OnDetaching()
        {
            
        }


    }
}
