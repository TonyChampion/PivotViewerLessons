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
using System.ComponentModel.Composition;

namespace Lessons.Lesson2
{
    [Export(typeof(ILesson))]
    public class Lesson2 : ILesson
    {
        #region ILesson Members

        public int LessonNumber
        {
            get { return 2; }
        }

        public string Title
        {
            get { return "Custom Actions"; }
        }
        #endregion
    }
}
