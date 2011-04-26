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

namespace Lessons.Lesson2
{
    public class Lesson2ViewModel
    {
        public Lesson2ViewModel()
        {
            Events = new ObservableCollection<string>();
        }

        public ObservableCollection<string> Events { get; set; }

    }
}
