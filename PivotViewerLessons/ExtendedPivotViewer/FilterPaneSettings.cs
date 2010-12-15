using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace ExtendedPivotViewer
{
    public class FilterPaneSettings : DependencyObject
    {
        public static readonly DependencyProperty VisibilityProperty = DependencyProperty.Register(
           "Visibility",
           typeof(Visibility),
           typeof(FilterPaneSettings),
           null
         );

        public Visibility Visibility
        {
            get { return (Visibility)GetValue(VisibilityProperty); }
            set { SetValue(VisibilityProperty, value); }
        }

        public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(
           "Background",
           typeof(Brush),
           typeof(FilterPaneSettings),
           null
         );

        public Brush Background
        {
            get { return (Brush)GetValue(BackgroundProperty); }
            set { SetValue(BackgroundProperty, value); }
        }        
    }
}
