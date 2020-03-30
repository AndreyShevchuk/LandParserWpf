using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PolygonViewerApp.Models
{
    class ScaleCanvasParam : INotifyPropertyChanged
    {
        private double _centrX =400;
        private double _centrY =600;

        private  int costylx=0;
        private int costyly = 0;

        public double CenterX { get {
                if (costylx == 0)
                {
                    costylx++;
                    return _centrX;
                }
                else
                {
                    return _centrX / 2;
                }
            } 
            set { _centrX = value; OnPropertyChanged("CenterX"); } 
        }

        public double CenterY { get 
            {
                if (costyly == 0)
                {
                    costylx++;
                    return _centrY;
                }
                else
                {
                    return _centrY / 2;
                }
            }
            set { _centrY = value; OnPropertyChanged("CenterY"); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
