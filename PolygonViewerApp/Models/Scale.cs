﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PolygonViewerApp.Models
{
    class Scale : INotifyPropertyChanged
    {
        private double _coefficientIncrease;
        public double CoefficientIncrease { get => _coefficientIncrease; 
            set { _coefficientIncrease = value; OnPropertyChanged("CoefficientIncrease"); } }
        public string ScaleParam
        {
            get
            {
                return $"1 : {(int)(comparativeSize / CoefficientIncrease)}";
            }
            set
            {
                var a = value.Split(':');
                double pars;
                double.TryParse(a[1], out pars);
                scaleParam = value;
                SetScaleParam(pars); 
                OnPropertyChanged("ScaleParam");
            }
        }

        private double comparativeSize;
        private string scaleParam;

       

        public Scale()
        {
            scaleParam = "";
            _coefficientIncrease = 1;
            comparativeSize = 2780;
        }

        public void Enlarge(double xZoom = 1.05)
        {
            CoefficientIncrease *= xZoom;
            OnPropertyChanged("ScaleParam");
        }

        public void Decrease(double xZoom = 1.05)
        {
            CoefficientIncrease /= xZoom;
            OnPropertyChanged("ScaleParam");
        }

        public void MouseWheelHandler(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                this.Enlarge();
            }

            if (e.Delta < 0)
            {
                this.Decrease();
            }
        }

        public void MouseDoun(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.Enlarge(1.5);
                }

                if (e.RightButton == MouseButtonState.Pressed)
                {
                    this.Decrease(1.5);
                }
            }
        }

        private void SetScaleParam(double value)
        {
            CoefficientIncrease = (comparativeSize/value);
            OnPropertyChanged("ScaleParam");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
