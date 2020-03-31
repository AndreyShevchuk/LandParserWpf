using Microsoft.Win32;
using PolygonViewerApp.Models;
using PolygonViewerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace PolygonViewerApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var viewModle = new MainWindowViewModel();
            InitializeComponent();
            DataContext = viewModle;
            this.MouseWheel += viewModle.MouseWheelHandler;
            viewModle.CanvasGetZindexPanel = GetZIndex;
            viewModle.CanvasSetZindexPanel = SetZIndex;

            panel.MouseDown += viewModle.Translate.MouseDoun;
            panel.MouseMove += viewModle.Translate.MouseMuve;
        }
        private void SetZIndex(UIElement e, int index)
        {
            Canvas.SetZIndex(e, index);
        }
        private int GetZIndex(UIElement e)
        {
             return Canvas.GetZIndex(e);
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
