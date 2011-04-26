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

namespace Lessons.Lesson6
{
    public class Lesson6ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> Fonts { get; set; }

        public Lesson6ViewModel()
        {
            Fonts = new ObservableCollection<string>()
                        {
                            "Arial",
                            "Arial Black",
                            "Arial Unicode MS",
                            "Calibri",
                            "Cambria",
                            "Cambria Math",
                            "Comic Sans MS",
                            "Candara",
                            "Consolas",
                            "Constantia",
                            "Corbel",
                            "Courier New",
                            "Georgia",
                            "Lucida Grande/Lucida Sans Unicode",
                            "Segoe UI",
                            "Symbol",
                            "Tahoma",
                            "Times New Roman",
                            "Trebuchet MS",
                            "Verdana",
                            "Wingdings",
                            "Wingdings 2",
                            "Wingdings 3"
                        };

            SelectedFontFamily = "Segoe UI";
            SelectedCatFont = SelectedFontFamily;
            SelectedSortFont = SelectedFontFamily;
            SelectedItemFont = SelectedFontFamily;
        }

        private string _selectedFontFamily;

        public string SelectedFontFamily {
            get
            {
                return _selectedFontFamily;
            }
            set 
            {
                _selectedFontFamily = value;
                NotifyPropertyChanged("SelectedFontFamily");
                SelectedCatFont = SelectedFontFamily;
                SelectedSortFont = SelectedFontFamily;
                SelectedItemFont = SelectedFontFamily;

            }
        }

        private string _selectedCatFont;

        public string SelectedCatFont
        {
            get
            {
                return _selectedCatFont;
            }
            set
            {
                _selectedCatFont = value;
                NotifyPropertyChanged("SelectedCatFont");
            }
        }

        private string _selectedSortFont;

        public string SelectedSortFont
        {
            get
            {
                return _selectedSortFont;
            }
            set
            {
                _selectedSortFont = value;
                NotifyPropertyChanged("SelectedSortFont");
            }
        }

        private string _selectedItemFont;

        public string SelectedItemFont
        {
            get
            {
                return _selectedItemFont;
            }
            set
            {
                _selectedItemFont = value;
                NotifyPropertyChanged("SelectedItemFont");
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
