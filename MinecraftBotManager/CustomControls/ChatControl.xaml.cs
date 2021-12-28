using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinecraftBotManager.CustomControls
{
    /// <summary>
    /// Логика взаимодействия для ChatControl.xaml
    /// </summary>
    public partial class ChatControl : UserControl
    {


        public object ChatQueue
        {
            get { return GetValue(ChatQueueProperty); }
            set { SetValue(ChatQueueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChatQueue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChatQueueProperty =
            DependencyProperty.Register("ChatQueue", typeof(object), typeof(ChatControl), new PropertyMetadata(new object()));


        public ChatControl()
        {
            InitializeComponent();
            ScrollChat.ScrollChanged += ScrollChat_ScrollChanged;
            ICollectionView view = ChatList.Items;



        }

        private void ScrollChat_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (ScrollChat.VerticalOffset == ScrollChat.ScrollableHeight)
            {

                ButtonExpand.Visibility = Visibility.Collapsed;
                ScrollChat.ScrollToBottom();
            }
            else
            {
                if (e.VerticalChange > 0)
                {
                    ButtonExpand.Visibility = Visibility.Visible;
                    ButtonExpand.Click += ButtonExpand_Click;
                }
                else if (e.VerticalChange < 0)
                {
                    ButtonExpand.Visibility = Visibility.Collapsed;
                }
            }
            //Rect rect = new Rect(ScrollChat.HorizontalOffset, ScrollChat.VerticalOffset, ScrollChat.ViewportWidth, ScrollChat.ViewportHeight );
            //for (int i = 0; i <= ChatList.Items.Count; i++)
            //{
            //    var container = ChatList.ItemContainerGenerator.ContainerFromIndex(i) as ContentPresenter;
            //    if (container != null)
            //    {
            //        ChatTextBlock chat = null;

            //        DataTemplate template = container.ContentTemplate;
            //        chat = (ChatTextBlock)template.FindName("MainTB", container);

            //        var offset = VisualTreeHelper.GetOffset(container);
            //        var bounds = new Rect(offset.X, offset.Y, container.ActualWidth, container.ActualHeight);
            //        ChatTextBlock chatText = container.Content as ChatTextBlock;
            //        if (rect.IntersectsWith(bounds))
            //        {
            //            chat.IsNeed = true;
            //        }
            //        else
            //        {
            //           chat.IsNeed = false;
            //        }
            //    }
            //}

        }

        public IEnumerable<T> Find<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, 1);
                    if (child != null && child is T)
                        yield return (T)child;
                    foreach (T item in Find<T>(child))
                        yield return item;
                }
            }
        }
        private void ButtonExpand_Click(object sender, RoutedEventArgs e)
        {
            ButtonExpand.Click -= ButtonExpand_Click;
            ButtonExpand.Visibility = Visibility.Collapsed;
            ScrollChat.ScrollChanged -= ScrollChat_ScrollChanged;
            DoubleAnimation animation = new DoubleAnimation(ScrollChat.VerticalOffset, ScrollChat.ExtentHeight, TimeSpan.FromMilliseconds(500));
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(animation);
            Storyboard.SetTarget(animation, ScrollChat);
            Storyboard.SetTargetProperty(animation, new PropertyPath(ScrollAnimateBehavior.AttachedBehaviors.ScrollAnimationBehavior.VerticalOffsetProperty));
            storyboard.Completed += (a, b) => { ScrollChat.ScrollChanged += ScrollChat_ScrollChanged; };
            storyboard.Begin();


        }
    }
}
