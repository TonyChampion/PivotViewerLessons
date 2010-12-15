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
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using Lessons;
using System.Windows.Markup;
using System.Windows.Resources;
using System.IO;
using System.Reflection;

namespace PivotViewerLessons
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();

            CompositionInitializer.SatisfyImports(this);

        }

        [ImportMany()]
        public ILesson[] Lessons
        {
            set { DataContext = value; }

        }

        private void lstLessons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            gridContainer.Children.Clear();
            gridContainer.Children.Add(LoadLessonContent(lstLessons.SelectedItem));
        }

        public static UserControl LoadLessonContent(object lesson)
        {
            Type type = lesson.GetType();
            Assembly assembly = type.Assembly;

            return assembly.CreateInstance(type.Namespace + ".Example") as UserControl;

        }

    }
}
