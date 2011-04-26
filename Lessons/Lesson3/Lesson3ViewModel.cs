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
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace Lessons.Lesson3
{
    public class Lesson3ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Backgrounds { get; set; }

        public Lesson3ViewModel()
        {
            Backgrounds = new ObservableCollection<string>() { "Solid Color", "Gradient", "Image" };
            SelectedBackground = "Solid Color";
        }

        private string _selectedBackgroud;

        public string SelectedBackground {
            get
            { 
                return _selectedBackgroud;
            }
            set 
            {
                _selectedBackgroud = value;
                NotifyPropertyChanged("SelectedBackground");
                NotifyPropertyChanged("SelectedBackgroundBrush");
            }
        }

        public Brush SelectedBackgroundBrush {
            get
            {
                switch(_selectedBackgroud) {
                    case "Solid Color":
                        return new SolidColorBrush(Color.FromArgb(255, 0, 110, 185));
                        break;
                    case "Gradient":
                        LinearGradientBrush gb = new LinearGradientBrush()
                        {
                            StartPoint = new Point(0.0, 0.0),
                            EndPoint = new Point(0.0, 1.0)
                        };
                        gb.GradientStops.Add(new GradientStop() { Color = Colors.Red, Offset = 0.0 });
                        gb.GradientStops.Add(new GradientStop() { Color = Colors.Orange, Offset = 1.0 });

                        return gb;
                        break;
                    case "Image":
                        ImageBrush brush = new ImageBrush();
                        brush.ImageSource = new BitmapImage(new Uri("/Lessons;component/Lesson3/Assets/silverlightbg.jpg", UriKind.Relative));
                        return brush;
                        break;
                }

                return null;
            }
        }

        private double _infoPaneA = 255;
        public double InfoPaneA
        {
            get { return _infoPaneA; }
            set
            {
                _infoPaneA = value;
                NotifyPropertyChanged("InfoPaneA");
                NotifyPropertyChanged("InfoPaneBackground");
            }
        }

        private double _infoPaneR = 255;
        public double InfoPaneR
        {
            get { return _infoPaneR; }
            set
            {
                _infoPaneR = value;
                NotifyPropertyChanged("InfoPaneR");
                NotifyPropertyChanged("InfoPaneBackground");
            }
        }

        private double _infoPaneG = 255;
        public double InfoPaneG
        {
            get { return _infoPaneG; }
            set
            {
                _infoPaneG = value;
                NotifyPropertyChanged("InfoPaneG");
                NotifyPropertyChanged("InfoPaneBackground");
            }
        }

        private double _infoPaneB = 255;
        public double InfoPaneB
        {
            get { return _infoPaneB; }
            set
            {
                _infoPaneB = value;
                NotifyPropertyChanged("InfoPaneB");
                NotifyPropertyChanged("InfoPaneBackground");
            }
        }

        public Brush InfoPaneBackground
        {
            get
            {
                Color col = Color.FromArgb(Convert.ToByte(_infoPaneA),
                                           Convert.ToByte(_infoPaneR),
                                           Convert.ToByte(_infoPaneG),
                                           Convert.ToByte(_infoPaneB));
               return new SolidColorBrush(col);
                
            }
        }

        private double _filterPaneA = 255;
        public double FilterPaneA
        {
            get { return _filterPaneA; }
            set
            {
                _filterPaneA = value;
                NotifyPropertyChanged("FilterPaneA");
                NotifyPropertyChanged("FilterPaneBackground");
            }
        }

        private double _filterPaneR = 255;
        public double FilterPaneR
        {
            get { return _filterPaneR; }
            set
            {
                _filterPaneR = value;
                NotifyPropertyChanged("FilterPaneR");
                NotifyPropertyChanged("FilterPaneBackground");
            }
        }

        private double _filterPaneG = 255;
        public double FilterPaneG
        {
            get { return _filterPaneG; }
            set
            {
                _filterPaneG = value;
                NotifyPropertyChanged("FilterPaneG");
                NotifyPropertyChanged("FilterPaneBackground");
            }
        }

        private double _filterPaneB = 255;
        public double FilterPaneB
        {
            get { return _filterPaneB; }
            set
            {
                _filterPaneB = value;
                NotifyPropertyChanged("FilterPaneB");
                NotifyPropertyChanged("FilterPaneBackground");
            }
        }

        public Brush FilterPaneBackground
        {
            get
            {
                Color col = Color.FromArgb(Convert.ToByte(_filterPaneA),
                                           Convert.ToByte(_filterPaneR),
                                           Convert.ToByte(_filterPaneG),
                                           Convert.ToByte(_filterPaneB));
                return new SolidColorBrush(col);

            }
        }
#region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler  PropertyChanged;

        public void NotifyPropertyChanged(string propertyName) 
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
#endregion
}
}
