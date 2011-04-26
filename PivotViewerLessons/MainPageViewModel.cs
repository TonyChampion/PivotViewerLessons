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
using Lessons;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

namespace PivotViewerLessons
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            CompositionInitializer.SatisfyImports(this);
        }

        private IEnumerable<ILesson> _lesons;

        [ImportMany()]
        public IEnumerable<ILesson> Lessons
        {
            set 
            {
                _lesons = from l in value
                          orderby l.LessonNumber
                          select l;
                NotifyPropertyChanged("Lessons");
            }
            get
            {
                return _lesons;
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
