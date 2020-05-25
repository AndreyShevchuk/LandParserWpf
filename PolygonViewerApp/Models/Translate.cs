using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PolygonViewerApp.Models
{
    class Translate : INotifyPropertyChanged
    {
        private double x;
        private double y;

        private double xScrol;
        private double yScrol;

        private double xposition;
        private double yposition;

        private Cursor cursor;

        public Cursor Cursor
        {
            get { return cursor; }
            set { cursor = value; OnPropertyChanged("Cursor"); }
        }
        public double XScrol
        {
            get { return xScrol; }
            set { xScrol = value; OnPropertyChanged("XScrol"); OnPropertyChanged("xPosition"); }
        }

        public double YScrol
        {
            get { return yScrol; }
            set { yScrol = value; OnPropertyChanged("YScrol"); OnPropertyChanged("yPosition"); }
        }

        public double xPosition
        {
            get { return xposition; }
            set { xposition = value; OnPropertyChanged("xPosition"); OnPropertyChanged("YScrol"); }
        }

        public double yPosition
        {
            get { return yposition; }
            set { yposition = value; OnPropertyChanged("yPosition"); OnPropertyChanged("YScrol"); }
        }


        public double X
        {
            get { return x; }
            set { x = value; OnPropertyChanged("X");  xScrol = Math.Abs(x); }
        }
        public double Y
        {
            get { return y; }
            set { y = value; OnPropertyChanged("Y"); yScrol = Math.Abs(y); }
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
                this.Cursor = Cursors.Cross;
                var tempPoint = e.GetPosition(null);
                X = (X - (CorectPoint.X - tempPoint.X));
                Y = (Y - (CorectPoint.Y - tempPoint.Y));
                CorectPoint = tempPoint;

                XScrol = X;
                YScrol = Y;
            }
            else
            {
                this.Cursor = null;
            }
            //this.Cursor = null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
