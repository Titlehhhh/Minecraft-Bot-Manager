using MinecraftBotManager.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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



        public INotifyCollectionChanged ChatItems
        {
            get { return this.DataContext as INotifyCollectionChanged; }

        }



        ScrollViewer ScrollChat;
        public ChatControl()
        {
            InitializeComponent();
            ScrollChat = GetScroll(ChatList, typeof(ScrollViewer)) as ScrollViewer;
            //ScrollChat.ScrollChanged += ScrollChat_ScrollChanged;
             ICollectionView view = ChatList.Items;
              view.CollectionChanged += View_CollectionChanged;
            
        }
        public static Visual GetScroll(Visual element,Type type)
        {
            if (element == null)
                return null;
            if (element.GetType() == type)
                return element;
            Visual foundElement = null;
            if (element is FrameworkElement)
                (element as FrameworkElement).ApplyTemplate();

            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                Visual visual = VisualTreeHelper.GetChild(element,i) as Visual;
                foundElement =GetScroll(visual, type);
                if (foundElement != null)
                    break;
            }
            return foundElement;
        }

        private bool flag = true;
        private void View_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (flag)
            {
                 ScrollChat.ScrollToBottom();
            }
        }

        private void ScrollChat_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (ScrollChat.VerticalOffset == ScrollChat.ScrollableHeight)
            {
                flag = true;
                ButtonExpand.Visibility = Visibility.Collapsed;
                ScrollChat.ScrollToBottom();
            }
            else
            {
                if (e.VerticalChange > 0)
                {
                    flag = false;
                    ButtonExpand.Visibility = Visibility.Visible;
                    ButtonExpand.Click += ButtonExpand_Click;
                }
                else if (e.VerticalChange < 0)
                {
                    flag = false;
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
