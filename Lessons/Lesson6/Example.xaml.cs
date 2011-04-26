using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Pivot.Internal.Controls;

namespace Lessons.Lesson6
{
    public partial class Example : UserControl
    {
        private Lesson6ViewModel _viewModel = new Lesson6ViewModel();

        public Example()
        {
            InitializeComponent();
            pvLesson6.Loaded += new RoutedEventHandler(pvLesson6_Loaded);
            pvLesson6.TemplateApplied += new EventHandler(pvLesson6_TemplateApplied);
            DataContext = _viewModel;
            _viewModel.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(_viewModel_PropertyChanged);
        }

        void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "SelectedFontFamily":
                    UpdateFontFamily(_viewModel.SelectedFontFamily);
                    break;
                case "SelectedCatFont":
                    UpdateCatFont(_viewModel.SelectedCatFont);
                    break;
                case "SelectedSortFont":
                    UpdateSortFont(_viewModel.SelectedSortFont);
                    break;
                case "SelectedItemFont":
                    UpdateItemFont(_viewModel.SelectedItemFont);
                    break;
            }
        }

        private void UpdateCatFont(string family)
        {
            RecursiveNamedUpdate(pvLesson6.FilterPaneScrollViewer, "m_categoryName", new FontFamily(family));
            
        }

        private void UpdateSortFont(string family)
        {
            RecursiveTypeUpdate(pvLesson6.FilterPaneScrollViewer, typeof(CycleButton), new FontFamily(family));

        }


        private void UpdateItemFont(string family)
        {
            RecursiveNamedUpdate(pvLesson6.FilterPaneScrollViewer, "PART_FacetSelectorButton", new FontFamily(family));
            RecursiveNamedUpdate(pvLesson6.FilterPaneScrollViewer, "PART_FacetName", new FontFamily(family));

        }

        private void RecursiveTypeUpdate(DependencyObject element, Type ctrlType, FontFamily family)
        {
            if (element is Control)
            {
                var ctr = element as Control;

                if (ctr.GetType() == ctrlType)
                    ctr.FontFamily = family;
            }

            int cnt = VisualTreeHelper.GetChildrenCount(element);

            for (int i = 0; i < cnt; i++)
            {
                var obj = VisualTreeHelper.GetChild(element, i);

                if (obj != null)
                    RecursiveTypeUpdate(obj, ctrlType, family);
            }
        }
        private void RecursiveNamedUpdate(DependencyObject element, string name, FontFamily family)
        {
            if (element is Control)
            {
                var ctr = element as Control;

                if (ctr.Name.Equals(name))
                    ctr.FontFamily = family;
            }

            int cnt = VisualTreeHelper.GetChildrenCount(element);

            for (int i = 0; i < cnt; i++)
            {
                var obj = VisualTreeHelper.GetChild(element, i);

                if (obj != null)
                    RecursiveNamedUpdate(obj, name, family);
            }
        }
        private void UpdateFontFamily(string family)
        {
            pvLesson6.FilterPaneView.FontFamily = new FontFamily(family);
            pvLesson6.FilterPaneScrollViewer.FontFamily = new FontFamily(family);

            RecursiveUpdate(pvLesson6.FilterPaneScrollViewer, new FontFamily(family));
        }

        private void RecursiveUpdate(DependencyObject element, FontFamily family)
        {
            if(element is Control)
                (element as Control).FontFamily = family;

            int cnt = VisualTreeHelper.GetChildrenCount(element);

            for(int i=0;i<cnt;i++)
            {
                var obj = VisualTreeHelper.GetChild(element, i);

                if(obj != null)
                    RecursiveUpdate(obj, family);
            }
        }
        void pvLesson6_TemplateApplied(object sender, EventArgs e)
        {
        }

        void pvLesson6_Loaded(object sender, RoutedEventArgs e)
        {
           
            pvLesson6.LoadCollection("http://labs.championds.com/MIX10/MIX10Collection.cxml", "");
        }

    }
}
