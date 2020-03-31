using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PolygonViewerApp.Models
{
    class Translate : INotifyPropertyChanged
    {
        private double x;
        private double y;
        public double X
        {
            get { return x; }
            set { x = value; OnPropertyChanged("X"); }
        }
        public double Y
        {
            get { return y; }
            set { y = value; OnPropertyChanged("Y"); }
        }

        private System.Windows.Point CorectPoint;

        public void MouseDoun(object sender, MouseButtonEventArgs e)
        {
            CorectPoint = e.GetPosition(null);
        }

        public void MouseMuve(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var tempPoint = e.GetPosition(null);
                X = (X - (CorectPoint.X - tempPoint.X));
                Y = (Y - (CorectPoint.Y - tempPoint.Y));
                CorectPoint = tempPoint;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
