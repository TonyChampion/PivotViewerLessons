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

namespace Lessons.Lesson4
{
    public partial class CustomLoading : UserControl
    {
        public CustomLoading()
        {
            InitializeComponent();
            DisplayText = "Loading";
        }

        public string DisplayText
        {
            get { return txtDisplay.Text; }
            set { txtDisplay.Text = value; }
        }

    }
}
