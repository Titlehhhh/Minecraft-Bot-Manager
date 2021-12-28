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
using System.ComponentModel;

namespace MinecraftBotManager.CustomControls
{
    /// <summary>
    /// Выполните шаги 1a или 1b, а затем 2, чтобы использовать этот пользовательский элемент управления в файле XAML.
    ///
    /// Шаг 1a. Использование пользовательского элемента управления в файле XAML, существующем в текущем проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MinecraftBotManager.CustomControls"
    ///
    ///
    /// Шаг 1б. Использование пользовательского элемента управления в файле XAML, существующем в другом проекте.
    /// Добавьте атрибут XmlNamespace в корневой элемент файла разметки, где он 
    /// будет использоваться:
    ///
    ///     xmlns:MyNamespace="clr-namespace:MinecraftBotManager.CustomControls;assembly=MinecraftBotManager.CustomControls"
    ///
    /// Потребуется также добавить ссылку из проекта, в котором находится файл XAML,
    /// на данный проект и пересобрать во избежание ошибок компиляции:
    ///
    ///     Щелкните правой кнопкой мыши нужный проект в обозревателе решений и выберите
    ///     "Добавить ссылку"->"Проекты"->[Поиск и выбор проекта]
    ///
    ///
    /// Шаг 2)
    /// Теперь можно использовать элемент управления в файле XAML.
    ///
    ///     <MyNamespace:EditBoxV1/>
    ///
    /// </summary>
    public class EditBox : Control, INotifyPropertyChanged
    {



        public string EditText
        {
            get { return (string)GetValue(EditTextProperty); }
            set { SetValue(EditTextProperty, value);
                System.Windows.MessageBox.Show(value);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EditText)));
            }
        }

        // Using a DependencyProperty as the backing store for EditText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditTextProperty =
            DependencyProperty.Register("EditText", typeof(string), typeof(EditBox), new FrameworkPropertyMetadata("asdasd",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));





        public bool IsInEditMode
        {
            get { return (bool)GetValue(IsInEditModeProperty); }
            set { SetValue(IsInEditModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsInEditMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInEditModeProperty =
            DependencyProperty.Register("IsInEditMode", typeof(bool), typeof(EditBox), new PropertyMetadata(false));




        public ICommand EditingCommand
        {
            get { return (ICommand)GetValue(EditingCommandProperty); }
            set { SetValue(EditingCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditingCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditingCommandProperty =
            DependencyProperty.Register("EditingCommand", typeof(ICommand), typeof(EditBox), new PropertyMetadata(null));



        public EditBox()
        {
            
        }
        private TextBox edittextbox;
        private TextBlock Maintb;

        public event PropertyChangedEventHandler PropertyChanged;

        public override void OnApplyTemplate()
        {
            

            edittextbox = GetTemplateChild("EditTextBox") as TextBox;
            Maintb = GetTemplateChild("MainTB") as TextBlock;

            edittextbox.LostFocus += Edittextbox_LostFocus;
            edittextbox.PreviewKeyDown += Edittextbox_PreviewKeyDown;
            LostFocus += EditBox_LostFocus;            
            base.OnApplyTemplate();
        }

        private void EditBox_LostFocus(object sender, RoutedEventArgs e)
        {
            IsInEditMode = false;
        }

        private void Edittextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                var exp = BindingOperations.GetBindingExpression(sender as TextBox, TextBox.TextProperty);
                exp?.UpdateSource();
                IsInEditMode = false;
            }
            
        }

        private void Edittextbox_LostFocus(object sender, RoutedEventArgs e)
        {
            IsInEditMode = false;
        }

        static EditBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditBox), new FrameworkPropertyMetadata(typeof(EditBox)));
        }
    
    }
}
