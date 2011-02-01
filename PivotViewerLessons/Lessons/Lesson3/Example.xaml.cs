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

namespace Lessons.Lesson3
{
    public partial class Example : UserControl
    {
        private Lesson3ViewModel _viewModel = new Lesson3ViewModel();

        public Example()
        {
            InitializeComponent();
            pvLesson3.Loaded += new RoutedEventHandler(pvLesson3_Loaded);
            pvLesson3.TemplateApplied += new EventHandler(pvLesson3_TemplateApplied);
            DataContext = _viewModel;
        }

        void pvLesson3_TemplateApplied(object sender, EventArgs e)
        {
            pvLesson3.CollectionViewBackground.Fill = new SolidColorBrush(Colors.Green);
        }

        void pvLesson3_Loaded(object sender, RoutedEventArgs e)
        {
            pvLesson3.LoadCollection("http://labs.championds.com/MIX10/MIX10Collection.cxml", "");
        }

        private void cbBackground_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.SelectedBackground = (string)e.AddedItems[0];
        }
    }
}
