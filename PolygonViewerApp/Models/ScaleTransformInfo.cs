using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonViewerApp.Models
{
    class ScaleTransformInfo
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        public double ScaleX { get; set; }
        public double ScaleY { get; set; }

        public ScaleTransformInfo(double centerX, double centerY, double scaleX, double scaleY)
        {
            CenterX = centerX;
            CenterY = centerY;
            ScaleX = scaleX;
            ScaleY = scaleY;
        }
    }
}
