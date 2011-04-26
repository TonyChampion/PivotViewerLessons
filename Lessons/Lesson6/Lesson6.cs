using System;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Lessons.Lesson6
{
    [Export(typeof(ILesson))]
    public class Lesson6 : ILesson
    {
        #region ILesson Members

        public int LessonNumber
        {
            get { return 6; }
        }

        public string Title
        {
            get { return "Filter Pane Fonts"; }
        }
        #endregion
    }
}
