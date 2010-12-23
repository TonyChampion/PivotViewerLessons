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
using System.Windows.Data;
using System.Windows.Pivot;

namespace Lessons.Lesson5
{
    public partial class Example : UserControl
    {
        CustomInfoPane _custInfoPane;

        public Example()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(Example_Loaded);
            pvLesson5.TemplateApplied += new EventHandler(pvLesson5_TemplateApplied);
        }

        void pvLesson5_TemplateApplied(object sender, EventArgs e)
        {
            pvLesson5.InfoPaneView.Width = 350;
            pvLesson5.InfoPaneView.Height = 300;
            pvLesson5.InfoPaneView.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            pvLesson5.SetInfoPaneScrollerData(_custInfoPane);
        }

        void Example_Loaded(object sender, RoutedEventArgs e)
        {
            _custInfoPane = new CustomInfoPane();
            pvLesson5.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(pvLesson5_PropertyChanged);
            pvLesson5.LoadCollection("http://content.getpivot.com/Collections/2009nflteams/2009nflteams.cxml", "");
        }

        void pvLesson5_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentItemId")
            {
                PivotItem item = pvLesson5.GetItem(pvLesson5.CurrentItemId);
                Uri newUri = null;

                try
                {
                    var stats = item.Facets["Statistics"];
                    var lnk = stats[0].Split(new string[] { "||" }, StringSplitOptions.None);

                    if (lnk.Length > 0 && !String.IsNullOrEmpty(lnk[0]))
                    {
                        newUri = new Uri(lnk[0]);
                    }
                }
                catch (Exception) { }

                _custInfoPane.StatsUri = newUri;
            }
        }
    }
}
