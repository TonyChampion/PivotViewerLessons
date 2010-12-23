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
using System.ComponentModel;
using System.Windows.Pivot;

namespace Lessons.Lesson5
{
    public class Lesson5ViewModel : INotifyPropertyChanged
    {

        private PivotItem _currentItemID;
        public PivotItem CurrentItemID
        {
            get { return _currentItemID; }
            set
            {
                _currentItemID = value;
                NotifyPropertyChanged("CurrentItemID");
            }
        }

        private Uri _statsUri;
        public Uri StatsUri
        {
            get { return _statsUri; }
            set
            {
                _statsUri = value;
                NotifyPropertyChanged("StatsUri");
            }
        }

        protected void LoadData()
        {
            //_currentItemID.Name
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
