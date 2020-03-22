using Microsoft.Win32;
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
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private double dx;
        private double dy;
        private double scale = 1;
        private System.Windows.Point lastMouseClick;

        private readonly Dictionary<string, Point> points = new Dictionary<string, Point>();
        private readonly Dictionary<string, PL> polylines = new Dictionary<string, PL>();

        private void Canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            CanvasTranslateTransform.X = e.NewSize.Width / 2 + dx;
            CanvasTranslateTransform.Y = e.NewSize.Height / 2 + dy;

            CanvasScaleTransform.CenterX = CanvasTranslateTransform.X;
            CanvasScaleTransform.CenterY = CanvasTranslateTransform.Y;
        }
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 1)
            {
                lastMouseClick = e.GetPosition(null);
            }
            if (e.ClickCount == 2)
            {
                var ds = 1.2;
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    scale *= ds;
                    CanvasScaleTransform.ScaleX = scale;
                    CanvasScaleTransform.ScaleY = scale;
                    e.Handled = true;
                }
                if (e.RightButton == MouseButtonState.Pressed)
                {
                    scale /= ds;
                    CanvasScaleTransform.ScaleX = scale;
                    CanvasScaleTransform.ScaleY = scale;
                    e.Handled = true;
                }
            }
        }
        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var position = e.GetPosition(null);

                var md = 0.01;

                var mdx = (position.X - lastMouseClick.X) * md;
                var mdy = (position.Y - lastMouseClick.Y) * md;

                dx += mdx;
                dy += mdy;

                CanvasTranslateTransform.X = (Width / 2) + dx;
                CanvasTranslateTransform.Y = (Height / 2) + dy;

                CanvasScaleTransform.CenterX = CanvasTranslateTransform.X;
                CanvasScaleTransform.CenterY = CanvasTranslateTransform.Y;
            }
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
