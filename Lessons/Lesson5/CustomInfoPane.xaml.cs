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
using System.Windows.Browser;

namespace Lessons.Lesson5
{
    public partial class CustomInfoPane : UserControl
    {
        public CustomInfoPane()
        {
            InitializeComponent();
        }

        private void btnStats_Click(object sender, RoutedEventArgs e)
        {
            HtmlPage.Window.Navigate(StatsUri, "_blank");

        }

        private Uri _statsUri;

        public Uri StatsUri
        {
            get { return _statsUri; }
            set
            {
                _statsUri = value;
                btnStats.IsEnabled = _statsUri != null;
            }
        }
    }

}
