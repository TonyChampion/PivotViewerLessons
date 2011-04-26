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

namespace Lessons.Lesson4
{
    public partial class Example : UserControl
    {
        CustomLoading _customLoading;
        public Example()
        {
            InitializeComponent();
            _customLoading = new CustomLoading();
            Loaded += new RoutedEventHandler(Example_Loaded);
            pvLesson4.TemplateApplied += new EventHandler(pvLesson4_TemplateApplied);
            pvLesson4.CollectionLoadingCompleted += new EventHandler(pvLesson4_CollectionLoadingCompleted);
        }

        void pvLesson4_CollectionLoadingCompleted(object sender, EventArgs e)
        {
            txtCustomText.IsEnabled = true;
        }

        void pvLesson4_TemplateApplied(object sender, EventArgs e)
        {
            pvLesson4.SetLoadingVisual(_customLoading);
        }

        void Example_Loaded(object sender, RoutedEventArgs e)
        {
            pvLesson4.IsEnabled = false;
            pvLesson4.LoadCollection("http://labs.championds.com/MIX10/MIX10Collection.cxml", "");
        }

        int cnt = 0;
        private void btnReload_Click(object sender, RoutedEventArgs e)
        {
            _customLoading.DisplayText = txtCustomText.Text;
            pvLesson4.IsEnabled = false;
            pvLesson4.LoadCollection("http://labs.championds.com/MIX10/MIX10Collection.cxml?a=" + cnt.ToString(), "asbc");
            cnt++;
            
        }
    }
}
