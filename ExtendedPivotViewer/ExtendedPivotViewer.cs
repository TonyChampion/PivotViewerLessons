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
using System.Windows.Pivot;
using System.Collections.Generic;
using Microsoft.Pivot.Internal.Views;

namespace ExtendedPivotViewer
{
    public delegate List<CustomAction> CustomActionDelegate(string itemId);

    public class ExtendedPivotViewer : PivotViewer
    {
        private List<CustomActionDelegate> registeredCustActDelegates;

        public FilterPaneSettings FilterPane { get; set; }
        public ExtendedPivotViewer()
        {
            registeredCustActDelegates = new List<CustomActionDelegate>();
            FilterPane = new FilterPaneSettings();
        }

        #region Custom Actions
        public void RegisterCustomActionDelegate(CustomActionDelegate custActDelegate)
        {
            if (!registeredCustActDelegates.Contains(custActDelegate))
                registeredCustActDelegates.Add(custActDelegate);
        }

        public void UnregisterCustomActionDelegate(CustomActionDelegate custActDelegate)
        {
            if (registeredCustActDelegates.Contains(custActDelegate))
                registeredCustActDelegates.Remove(custActDelegate);
        }

        protected override List<CustomAction> GetCustomActionsForItem(string itemId)
        {
            List<CustomAction> actions = new List<CustomAction>();

            foreach (var del in registeredCustActDelegates)
            {
                actions.AddRange(del(itemId));
            }

            return actions;
        }
        #endregion

        #region AppliedTemplate Event
        public event EventHandler TemplateApplied;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (TemplateApplied != null)
                TemplateApplied(this, new EventArgs());
            
        }
        #endregion

        #region DependencyProperties

        #region CollectionBackground
        public static readonly DependencyProperty CollectionBackgroundProperty = DependencyProperty.Register(
          "CollectionBackground",
          typeof(Brush),
          typeof(ExtendedPivotViewer),
          new PropertyMetadata(null, new PropertyChangedCallback(OnCollectionBackgroundChanged))
        );

        public static void OnCollectionBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExtendedPivotViewer pv = (ExtendedPivotViewer)d;
            try 
            {
                pv.CollectionViewBackground.Fill = e.NewValue as Brush;
            }
            catch (Exception) { }
        }

        public Brush CollectionBackground
        {
            get { return (Brush)GetValue(CollectionBackgroundProperty); }
            set { SetValue(CollectionBackgroundProperty, value); }
        }
        #endregion

        #region InfoPaneBackground
        public static readonly DependencyProperty InfoPaneBackgroundProperty = DependencyProperty.Register(
          "InfoPaneBackground",
          typeof(Brush),
          typeof(ExtendedPivotViewer),
          new PropertyMetadata(null, new PropertyChangedCallback(OnInfoPaneBackgroundChanged))
        );

        public static void OnInfoPaneBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExtendedPivotViewer pv = (ExtendedPivotViewer)d;
            try
            {
                pv.InfoPaneViewBackgroundRectangle.Fill = e.NewValue as Brush;
            }
            catch (Exception) { }
        }

        public Brush InfoPaneBackground
        {
            get { return (Brush)GetValue(InfoPaneBackgroundProperty); }
            set { SetValue(InfoPaneBackgroundProperty, value); }
        }
        #endregion

        #region ShowInfoPane
        public static readonly DependencyProperty ShowInfoPaneProperty = DependencyProperty.Register(
          "ShowInfoPane",
          typeof(bool),
          typeof(ExtendedPivotViewer),
          new PropertyMetadata(true, new PropertyChangedCallback(OnShowInfoPaneChanged))
        );

        public static void OnShowInfoPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExtendedPivotViewer pv = (ExtendedPivotViewer)d;
            try
            {
                pv.InfoPaneView.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (Exception) { }
        }

        public bool ShowInfoPane
        {
            get { return (bool)GetValue(ShowInfoPaneProperty); }
            set { SetValue(ShowInfoPaneProperty, value); }
        }
        #endregion

        #region FilterPaneBackground
        public static readonly DependencyProperty FilterPaneBackgroundProperty = DependencyProperty.Register(
          "FilterPaneBackground",
          typeof(Brush),
          typeof(ExtendedPivotViewer),
          new PropertyMetadata(null, new PropertyChangedCallback(OnFilterPaneBackgroundChanged))
        );

        public static void OnFilterPaneBackgroundChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExtendedPivotViewer pv = (ExtendedPivotViewer)d;
            try
            {
                pv.FilterPaneViewBackgroundRectangle2.Fill = new SolidColorBrush(Colors.Transparent);
                pv.FilterPaneViewBackgroundRectangle.Fill = e.NewValue as Brush;
            }
            catch (Exception) { }
        }

        public Brush FilterPaneBackground
        {
            get { return (Brush)GetValue(FilterPaneBackgroundProperty); }
            set { SetValue(FilterPaneBackgroundProperty, value); }
        }
        #endregion

        #region ShowFilterPane
        public static readonly DependencyProperty ShowFilterPaneProperty = DependencyProperty.Register(
          "ShowFilterPane",
          typeof(bool),
          typeof(ExtendedPivotViewer),
          new PropertyMetadata(true, new PropertyChangedCallback(OnShowFilterPaneChanged))
        );

        public static void OnShowFilterPaneChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExtendedPivotViewer pv = (ExtendedPivotViewer)d;
            try
            {
                pv.FilterPaneView.Visibility = (bool)e.NewValue ? Visibility.Visible : Visibility.Collapsed;
            }
            catch (Exception) { }
        }

        public bool ShowFilterPane
        {
            get { return (bool)GetValue(ShowFilterPaneProperty); }
            set { SetValue(ShowFilterPaneProperty, value); }
        }
        #endregion

        #region Custom Loading Visual
        public void SetLoadingVisual(UserControl newLoading)
        {
            Grid cont = LoadingVisualContainer;
            newLoading.Name = "PART_LoadingVisual";

            cont.VerticalAlignment = VerticalAlignment.Stretch;
            cont.HorizontalAlignment = HorizontalAlignment.Stretch;
            cont.Children.RemoveAt(0);
            cont.Children.Add(newLoading);

        }

        public UIElement CurrentLoadingVisual
        {
            get
            {
                return LoadingVisualContainer.Children[0];
            }
        }

        #endregion

        public static readonly DependencyProperty FilterPaneSettingsProperty = DependencyProperty.Register(
           "FilterPaneSettings",
           typeof(FilterPaneSettings),
           typeof(ExtendedPivotViewer),
           null
         );

        public FilterPaneSettings FilterPaneSettings
        {
            get { return (FilterPaneSettings)GetValue(FilterPaneSettingsProperty); }
            set { SetValue(FilterPaneSettingsProperty, value); }
        }
        #endregion

        #region InfoPane Methods

        public void SetInfoPaneScrollerData(UserControl newPane)
        {
            ScrollViewer scroll = (ScrollViewer)InfoPaneView.FindName("ScrollRoot");
            scroll.Content = newPane;
//            ScrollContentPresenter pres = (ScrollContentPresenter)InfoPaneView.FindName("ScrollContentPresenter");
//            pres.Content = newPane;
        }

        #endregion

        #region Access to Internal PivotViewer Components

        public Grid MainContainer
        {
            get
            {
                return (Grid)VisualTreeHelper.GetChild(this, 0);
            }
        }

        public CollectionViewerView CollectionView
        {
            get
            {
                return (CollectionViewerView)MainContainer.Children[0];
            }
        }

        public Grid CollectionViewGrid
        {
            get 
            { 
                return (Grid)CollectionView.FindName("LayoutRoot"); 
            }
        }

        public Rectangle CollectionViewBackground
        {
            get
            {
                return (Rectangle)CollectionViewGrid.Children[0];
            }
        }

        public InfoPaneView InfoPaneView
        {
            get
            {
                return (InfoPaneView)CollectionView.FindName("PART_Infopane");
            }
        }

        public Rectangle InfoPaneViewBackgroundRectangle
        {
            get
            {
                return (Rectangle)((Grid)InfoPaneView.FindName("MainPanel")).Children[0];
            }
        }

        public FilterPaneView FilterPaneView
        {
            get
            {
                return (FilterPaneView)CollectionView.FindName("PART_FilterPane");
            }
        }

        public Rectangle FilterPaneViewBackgroundRectangle
        {
            get
            {
                return (Rectangle)FilterPaneView.FindName("m_Background");
            }
        }

        public Rectangle FilterPaneViewBackgroundRectangle2
        {
            get
            {
                return (Rectangle)((Grid)FilterPaneView.FindName("FilterPaneRoot")).Children[0];
            }
        }

        public ScrollViewer FilterPaneScrollViewer
        {
            get { return (ScrollViewer) FilterPaneView.FindName("PART_PaneScrollViewer"); }
        }
        public Grid LoadingVisualContainer
        {
            get
            {
                return (Grid)CollectionViewGrid.Children[3];
            }
        }
        #endregion

    }
}
