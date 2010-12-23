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
using System.Collections.ObjectModel;

namespace Lessons.Lesson1
{
    public partial class Example : UserControl
    {
        private Lesson1ViewModel _viewModel = new Lesson1ViewModel();

        public Example()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Example_Loaded);

            pvLesson1.CollectionLoadingFailed += new EventHandler<System.Windows.Pivot.CollectionErrorEventArgs>(pvLesson1_CollectionLoadingFailed);
            pvLesson1.CollectionLoadingCompleted += new EventHandler(pvLesson1_CollectionLoadingCompleted);
            pvLesson1.ItemDoubleClicked += new EventHandler<System.Windows.Pivot.ItemEventArgs>(pvLesson1_ItemDoubleClicked);
            pvLesson1.Loaded += new RoutedEventHandler(pvLesson1_Loaded);
            pvLesson1.LinkClicked += new EventHandler<System.Windows.Pivot.LinkEventArgs>(pvLesson1_LinkClicked);
            DataContext = _viewModel;    
        
        }

        void pvLesson1_LinkClicked(object sender, System.Windows.Pivot.LinkEventArgs e)
        {
            _viewModel.Events.Add("Clicked Link : " + e.Link.ToString());
        }

        void pvLesson1_ItemDoubleClicked(object sender, System.Windows.Pivot.ItemEventArgs e)
        {
            _viewModel.Events.Add("Item " + e.ItemId + " Double Clicked");
        }

        void pvLesson1_CollectionLoadingCompleted(object sender, EventArgs e)
        {
            _viewModel.Events.Add("Load Collection Completed");

        }

        void pvLesson1_Loaded(object sender, RoutedEventArgs e)
        {
           // pvLesson1.LoadCollection("http://localhost:123/ClientBin/MIXCollection.cxml", "");
            pvLesson1.LoadCollection("http://content.getpivot.com/Collections/2009nflteams/2009nflteams.cxml", "");
        }

        void pvLesson1_CollectionLoadingFailed(object sender, System.Windows.Pivot.CollectionErrorEventArgs e)
        {
            _viewModel.Events.Add("Load Collection Failed");
        }

        void Example_Loaded(object sender, RoutedEventArgs e)
        {
            

        }
    }
}
