using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace MinecraftBotManager.Asists
{
    /// <summary>
    /// Exposes attached dependency properties that provide 
    /// additional functionality for <see cref="Popup"/> controls.
    /// </summary>
    /// <seealso cref="Popup"/>
    /// <seealso cref="DependencyProperty"/>
    public static class PopupProperties
    {


        #region Properties

        #region IsMonitoringState attached dependency property

        /// <summary>
        /// Attached <see cref="DependencyProperty"/>. This property 
        /// registers (<b>true</b>) or unregisters (<b>false</b>) a 
        /// <see cref="Popup"/> from the popup monitoring mechanism 
        /// used internally by <see cref="PopupProperties"/> to keep 
        /// the <see cref="Popup"/> in synchrony with the 
        /// <see cref="PopupProperties"/>' attached properties. A 
        /// <see cref="Popup"/> will be automatically unregistered from
        /// this mechanism after it is unloaded.
        /// </summary>
        /// <seealso cref="Popup"/>
        private static readonly DependencyProperty IsMonitoringStateProperty
            = DependencyProperty.RegisterAttached("IsMonitoringState",
                typeof(bool), typeof(PopupProperties),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(IsMonitoringStatePropertyChanged)));

        private static void IsMonitoringStatePropertyChanged(
            DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            Popup popup = (Popup)dObject;
            bool value = (bool)e.NewValue;
            if (value)
            {
                // Attach popup.
                popup.Opened += Popup_Opened;
                popup.Unloaded += Popup_Unloaded;

                // Update popup.
                UpdateLocation(popup);
            }
            else
            {
                // Detach popup.
                popup.Opened -= Popup_Opened;
                popup.Unloaded -= Popup_Unloaded;
            }
        }


        private static bool GetIsMonitoringState(Popup popup)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));
            return (bool)popup.GetValue(IsMonitoringStateProperty);
        }

        private static void SetIsMonitoringState(Popup popup, bool isMonitoringState)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));
            popup.SetValue(IsMonitoringStateProperty, isMonitoringState);
        }

        #endregion


        #region HorizontalPlacementAlignment attached dependency property

        public static readonly DependencyProperty HorizontalPlacementAlignmentProperty
            = DependencyProperty.RegisterAttached("HorizontalPlacementAlignment",
                typeof(AlignmentX), typeof(PopupProperties),
                new FrameworkPropertyMetadata(AlignmentX.Left,
                    FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(HorizontalPlacementAlignmentPropertyChanged)),
                new ValidateValueCallback(HorizontalPlacementAlignmentPropertyValidate));

        private static void HorizontalPlacementAlignmentPropertyChanged(
            DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            Popup popup = (Popup)dObject;
            SetIsMonitoringState(popup, true);
            UpdateLocation(popup);
        }

        private static bool HorizontalPlacementAlignmentPropertyValidate(object obj)
        {
            return Enum.IsDefined(typeof(AlignmentX), obj);
        }

        public static AlignmentX GetHorizontalPlacementAlignment(Popup popup)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));
            return (AlignmentX)popup.GetValue(HorizontalPlacementAlignmentProperty);
        }

        public static void SetHorizontalPlacementAlignment(Popup popup, AlignmentX alignment)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));
            popup.SetValue(HorizontalPlacementAlignmentProperty, alignment);
        }

        #endregion


        #region VerticalPlacementAlignment attached dependency property

        public static readonly DependencyProperty VerticalPlacementAlignmentProperty
            = DependencyProperty.RegisterAttached("VerticalPlacementAlignment",
                typeof(AlignmentY), typeof(PopupProperties),
                new FrameworkPropertyMetadata(AlignmentY.Top,
                    FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(VerticalPlacementAlignmentPropertyChanged)),
                new ValidateValueCallback(VerticalPlacementAlignmentPropertyValidate));

        private static void VerticalPlacementAlignmentPropertyChanged(
            DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            Popup popup = (Popup)dObject;
            SetIsMonitoringState(popup, true);
            UpdateLocation(popup);
        }

        private static bool VerticalPlacementAlignmentPropertyValidate(object obj)
        {
            return Enum.IsDefined(typeof(AlignmentY), obj);
        }

        public static AlignmentY GetVerticalPlacementAlignment(Popup popup)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));
            return (AlignmentY)popup.GetValue(VerticalPlacementAlignmentProperty);
        }

        public static void SetVerticalPlacementAlignment(Popup popup, AlignmentY alignment)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));
            popup.SetValue(VerticalPlacementAlignmentProperty, alignment);
        }

        #endregion


        #region HorizontalOffset attached dependency property

        public static readonly DependencyProperty HorizontalOffsetProperty
            = DependencyProperty.RegisterAttached("HorizontalOffset",
                typeof(double), typeof(PopupProperties),
                new FrameworkPropertyMetadata(0d,
                    FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(HorizontalOffsetPropertyChanged)),
                new ValidateValueCallback(HorizontalOffsetPropertyValidate));

        private static void HorizontalOffsetPropertyChanged(
            DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            Popup popup = (Popup)dObject;
            SetIsMonitoringState(popup, true);
            UpdateLocation(popup);
        }

        private static bool HorizontalOffsetPropertyValidate(object obj)
        {
            double value = (double)obj;
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        public static double GetHorizontalOffset(Popup popup)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));
            return (double)popup.GetValue(HorizontalOffsetProperty);
        }

        public static void SetHorizontalOffset(Popup popup, double offset)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(offset));
            popup.SetValue(HorizontalOffsetProperty, offset);
        }

        #endregion


        #region VerticalOffset attached dependency property

        public static readonly DependencyProperty VerticalOffsetProperty
            = DependencyProperty.RegisterAttached("VerticalOffset",
                typeof(double), typeof(PopupProperties),
                new FrameworkPropertyMetadata(0d,
                    FrameworkPropertyMetadataOptions.None,
                    new PropertyChangedCallback(VerticalOffsetPropertyChanged)),
                new ValidateValueCallback(VerticalOffsetPropertyValidate));

        private static void VerticalOffsetPropertyChanged(
            DependencyObject dObject, DependencyPropertyChangedEventArgs e)
        {
            Popup popup = (Popup)dObject;
            SetIsMonitoringState(popup, true);
            UpdateLocation(popup);
        }

        private static bool VerticalOffsetPropertyValidate(object obj)
        {
            double value = (double)obj;
            return !double.IsNaN(value) && !double.IsInfinity(value);
        }

        public static double GetVerticalOffset(Popup popup)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));
            return (double)popup.GetValue(VerticalOffsetProperty);
        }

        public static void SetVerticalOffset(Popup popup, double offset)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(offset));
            popup.SetValue(VerticalOffsetProperty, offset);
        }

        #endregion

        #endregion Properties


        #region Methods

        private static void OnMonitorState(Popup popup)
        {
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));

            UpdateLocation(popup);
        }


        private static void UpdateLocation(Popup popup)
        {
            // Validate parameters.
            if (popup is null)
                throw new ArgumentNullException(nameof(popup));

            // If the popup is not open, we don't need to update its position yet.
            if (!popup.IsOpen)
                return;

            // Setup initial variables.
            double offsetX = 0d;
            double offsetY = 0d;
            PlacementMode placement = popup.Placement;
            UIElement placementTarget = popup.PlacementTarget;
            Rect placementRect = popup.PlacementRectangle;

            // If the popup placement mode is an edge of the placement target, 
            // determine the alignment offset.
            if (placement == PlacementMode.Top || placement == PlacementMode.Bottom
                || placement == PlacementMode.Left || placement == PlacementMode.Right)
            {
                // Try to get the popup size. If its size is empty, use the size 
                // of its child, if any child exists.
                Size popupSize = GetElementSize(popup);
                UIElement child = popup.Child;
                if ((popupSize.IsEmpty || popupSize.Width <= 0d || popupSize.Height <= 0d)
                    && child != null)
                {
                    popupSize = GetElementSize(child);
                }
                // Get the placement rectangle size. If it's empty, get the 
                // placement target's size, if a target is set.
                Size targetSize;
                if (placementRect.Width > 0d && placementRect.Height > 0d)
                    targetSize = placementRect.Size;
                else if (placementTarget != null)
                    targetSize = GetElementSize(placementTarget);
                else
                    targetSize = Size.Empty;

                // If we have a valid popup size and a valid target size, determine 
                // the offset needed to align the popup to the target rectangle.
                if (!popupSize.IsEmpty && popupSize.Width > 0d && popupSize.Height > 0d
                    && !targetSize.IsEmpty && targetSize.Width > 0d && targetSize.Height > 0d)
                {
                    switch (placement)
                    {
                        // Horizontal alignment offset.
                        case PlacementMode.Top:
                        case PlacementMode.Bottom:
                            switch (GetHorizontalPlacementAlignment(popup))
                            {
                                case AlignmentX.Left:
                                    offsetX = 0d;
                                    break;
                                case AlignmentX.Center:
                                    offsetX = -(popupSize.Width - targetSize.Width) / 2d;
                                    break;
                                case AlignmentX.Right:
                                    offsetX = -(popupSize.Width - targetSize.Width);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        // Vertical alignment offset.
                        case PlacementMode.Left:
                        case PlacementMode.Right:
                            switch (GetVerticalPlacementAlignment(popup))
                            {
                                case AlignmentY.Top:
                                    offsetY = 0d;
                                    break;
                                case AlignmentY.Center:
                                    offsetY = -(popupSize.Height - targetSize.Height) / 2d;
                                    break;
                                case AlignmentY.Bottom:
                                    offsetY = -(popupSize.Height - targetSize.Height);
                                    break;
                                default:
                                    break;
                            }
                            break;
                        default:
                            break;
                    }
                }
            }

            // Add the developer specified offsets to the offsets we've calculated.
            offsetX += GetHorizontalOffset(popup);
            offsetY += GetVerticalOffset(popup);

            // Apply the final computed offsets to the popup.
            popup.SetCurrentValue(Popup.HorizontalOffsetProperty, offsetX);
            popup.SetCurrentValue(Popup.VerticalOffsetProperty, offsetY);
        }


        private static Size GetElementSize(UIElement element)
        {
            if (element is null)
                return new Size(0d, 0d);
            else if (element is FrameworkElement frameworkElement)
                return new Size(frameworkElement.ActualWidth, frameworkElement.ActualHeight);
            else
                return element.RenderSize;
        }

        #endregion Methods


        #region Event handlers

        private static void Popup_Unloaded(object sender, RoutedEventArgs e)
        {
            if (sender is Popup popup)
            {
                // Stop monitoring the popup state, because it was unloaded.
                SetIsMonitoringState(popup, false);
            }
        }


        private static void Popup_Opened(object sender, EventArgs e)
        {
            if (sender is Popup popup)
            {
                OnMonitorState(popup);
            }
        }

        #endregion Event handlers


    }
}

