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
using System.Collections.ObjectModel;

namespace Lessons.Lesson1
{
    public class Lesson1ViewModel
    {
        public Lesson1ViewModel()
        {
            Events = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Events { get; set; }
    }
}
