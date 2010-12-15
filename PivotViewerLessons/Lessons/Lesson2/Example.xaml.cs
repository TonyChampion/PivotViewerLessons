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
using System.Windows.Pivot;
using ExtendedPivotViewer;

namespace Lessons.Lesson2
{
    public partial class Example : UserControl
    {
        private Lesson2ViewModel _viewModel = new Lesson2ViewModel();

        public Example()
        {
            InitializeComponent();

            pvLesson2.Loaded += new RoutedEventHandler(pvLesson2_Loaded);
            pvLesson2.ItemActionExecuted += new EventHandler<ItemActionEventArgs>(pvLesson2_ItemActionExecuted);
            sample1Delegate = new CustomActionDelegate(CreateSample1CustomAction);
            sample2Delegate = new CustomActionDelegate(CreateSample2CustomAction);

            DataContext = _viewModel;
        }

        #region Custom Action Delegates

        private CustomActionDelegate sample1Delegate;

        List<CustomAction> CreateSample1CustomAction(string itemId)
        {
            List<CustomAction> ret = new List<CustomAction>();

            PivotItem item = pvLesson2.GetItem(itemId);

            ret.Add(new CustomAction("Sample 1", new Uri("/Lessons;component/Lesson2/Assets/Add.png", UriKind.Relative), "Sample 1 action item : " + item.Name, "sample1"));

            return ret;
        }

        private CustomActionDelegate sample2Delegate;

        List<CustomAction> CreateSample2CustomAction(string itemId)
        {
            List<CustomAction> ret = new List<CustomAction>();

            PivotItem item = pvLesson2.GetItem(itemId);

            ret.Add(new CustomAction("Sample 2", new Uri("/Lessons;component/Lesson2/Assets/Add.png", UriKind.Relative), "Sample 2 action item : " + item.Name, "sample2"));

            return ret;
        }

        #endregion

        #region Event Handlers

        void pvLesson2_ItemActionExecuted(object sender, ItemActionEventArgs e)
        {
            _viewModel.Events.Add("[" + e.CustomActionId + "] - " + e.ItemId);
        }

        void pvLesson2_Loaded(object sender, RoutedEventArgs e)
        {
            pvLesson2.LoadCollection("http://content.getpivot.com/Collections/2009nflteams/2009nflteams.cxml", "");
            pvLesson2.RegisterCustomActionDelegate(sample1Delegate);
        }

        private void cbSample1Action_Checked(object sender, RoutedEventArgs e)
        {
            if (cbSample1Action.IsChecked.Value)
                pvLesson2.RegisterCustomActionDelegate(sample1Delegate);
            else
                pvLesson2.UnregisterCustomActionDelegate(sample1Delegate);

        }
        private void cbSample2Action_Checked(object sender, RoutedEventArgs e)
        {
            if (cbSample2Action.IsChecked.Value)
                pvLesson2.RegisterCustomActionDelegate(sample2Delegate);
            else
                pvLesson2.UnregisterCustomActionDelegate(sample2Delegate);

        }
        #endregion

    }
}
