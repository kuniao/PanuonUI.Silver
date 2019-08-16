﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class ScrollViewerHelper
    {
        #region TrackBrush
        public static Brush GetTrackBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(TrackBrushProperty);
        }

        public static void SetTrackBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(TrackBrushProperty, value);
        }

        public static readonly DependencyProperty TrackBrushProperty =
            DependencyProperty.RegisterAttached("TrackBrush", typeof(Brush), typeof(ScrollViewerHelper));
        #endregion

        #region ThumbBrush
        public static Brush GetThumbBrush(DependencyObject obj)
        {
            return (Brush)obj.GetValue(ThumbBrushProperty);
        }

        public static void SetThumbBrush(DependencyObject obj, Brush value)
        {
            obj.SetValue(ThumbBrushProperty, value);
        }

        public static readonly DependencyProperty ThumbBrushProperty =
            DependencyProperty.RegisterAttached("ThumbBrush", typeof(Brush), typeof(ScrollViewerHelper));
        #endregion

        #region ScrollBarCornerRadius
        public static CornerRadius GetScrollBarCornerRadius(DependencyObject obj)
        {
            return (CornerRadius)obj.GetValue(ScrollBarCornerRadiusProperty);
        }

        public static void SetScrollBarCornerRadius(DependencyObject obj, CornerRadius value)
        {
            obj.SetValue(ScrollBarCornerRadiusProperty, value);
        }

        public static readonly DependencyProperty ScrollBarCornerRadiusProperty =
            DependencyProperty.RegisterAttached("ScrollBarCornerRadius", typeof(CornerRadius), typeof(ScrollViewerHelper));

        #endregion

        #region ScrollBarThickness
        public static double GetScrollBarThickness(DependencyObject obj)
        {
            return (double)obj.GetValue(ScrollBarThicknessProperty);
        }

        public static void SetScrollBarThickness(DependencyObject obj, double value)
        {
            obj.SetValue(ScrollBarThicknessProperty, value);
        }

        public static readonly DependencyProperty ScrollBarThicknessProperty =
            DependencyProperty.RegisterAttached("ScrollBarThickness", typeof(double), typeof(ScrollViewerHelper));
        #endregion

        #region (Internal) ScrollViewerHook
        public static bool GetScrollViewerHook(DependencyObject obj)
        {
            return (bool)obj.GetValue(ScrollViewerHookProperty);
        }

        public static void SetScrollViewerHook(DependencyObject obj, bool value)
        {
            obj.SetValue(ScrollViewerHookProperty, value);
        }

        public static readonly DependencyProperty ScrollViewerHookProperty =
            DependencyProperty.RegisterAttached("ScrollViewerHook", typeof(bool), typeof(ScrollViewerHelper), new PropertyMetadata(OnScrollViewerHookChanged));

        private static void OnScrollViewerHookChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var scrollViewer = d as ScrollViewer;
            scrollViewer.PreviewMouseWheel += ScrollViewer_PreviewMouseWheel;
        }

        private static void ScrollViewer_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            var scrollViewer = sender as ScrollViewer;

            if (e.Delta > 0)
            {
                if (scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible)
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 2);
                else if (scrollViewer.ComputedHorizontalScrollBarVisibility == Visibility.Visible)
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta / 2);
                else if (scrollViewer.VerticalScrollBarVisibility != ScrollBarVisibility.Disabled)
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 2);
                else if (scrollViewer.HorizontalScrollBarVisibility != ScrollBarVisibility.Disabled)
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta / 2);
                else
                    return;
            }
            else
            {
                if (scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible)
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 2);
                else if (scrollViewer.ComputedHorizontalScrollBarVisibility == Visibility.Visible)
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta / 2);
                else if (scrollViewer.VerticalScrollBarVisibility != ScrollBarVisibility.Disabled)
                    scrollViewer.ScrollToVerticalOffset(scrollViewer.VerticalOffset - e.Delta / 2);
                else if (scrollViewer.HorizontalScrollBarVisibility != ScrollBarVisibility.Disabled)
                    scrollViewer.ScrollToHorizontalOffset(scrollViewer.HorizontalOffset - e.Delta / 2);
                else
                    return;
            }


            if (scrollViewer.ComputedVerticalScrollBarVisibility == Visibility.Visible || scrollViewer.ComputedHorizontalScrollBarVisibility == Visibility.Visible)
                e.Handled = true;
        }
        #endregion
    }
}