using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using PolygonViewerApp.Models;

namespace PolygonViewerApp
{

    class PraseInfoLandsPlot
    {
        public UkrainianCadastralExchangeFile data { get; set; }

        private System.Windows.Point corectPoint;
        private Dictionary<string, System.Windows.Point> points;
        public Dictionary<string, System.Windows.Shapes.Polyline> polilines;

        public PraseInfoLandsPlot(UkrainianCadastralExchangeFile data)
        {
            this.data = data;
            points = new Dictionary<string, System.Windows.Point>();
            polilines = new Dictionary<string, System.Windows.Shapes.Polyline>();
            GetCortctPointPoint();
            GetPolilines();
        }

        public ICollection<LandPlot> GetLandPlots()
        {
            var landsPlotsColections = new List<LandPlot>();
            foreach (var item1 in data.InfoPart.CadastralZoneInfo.CadastralQuarters.CadastralQuarterInfo.Parcels.ParcelInfo/*[0].MetricInfo.Externals.Boundary.Lines.Line*/)
            {
                foreach (var item in item1.LandsParcel.LandParcelInfo)
                {
                    var LandInfo = new LandInfo(item1, data);
                    var tempBuferLines = new List<System.Windows.Shapes.Polyline>();
                    foreach (var item2 in item.MetricInfo.Externals.Boundary.Lines.Line)
                    {
                        tempBuferLines.Add(polilines[item2.ULID]);
                    }
                    landsPlotsColections.Add(new LandPlot(tempBuferLines, LandInfo));
                }
            }
            return landsPlotsColections;
        }
        private void GetCortctPointPoint()
        {
            var minX = Double.MaxValue;
            var minY = Double.MaxValue;

            foreach (var point in data.InfoPart.MetricInfo.PointInfo.Point)
            {
                minX = Math.Min(minX, point.X);
                minY = Math.Min(minY, point.Y);
                points[point.PN] = new System.Windows.Point(point.X, point.Y);
            }
            corectPoint = new System.Windows.Point(minX, minY);
        }
        private void GetPolilines()
        {
            foreach (var polyline in data.InfoPart.MetricInfo.Polyline.PL)
            {
                var graphicsPolyline = new System.Windows.Shapes.Polyline
                {
                    Stroke = Brushes.Red,
                    StrokeThickness = 2,
                    Points = new PointCollection()
                };

                foreach (var pointId in polyline.Points.P)
                {
                    var point = points[pointId];
                    var y = point.X - corectPoint.X;
                    var x = point.Y - corectPoint.Y;
                    graphicsPolyline.Points.Add(new System.Windows.Point(x, y));
                }
                polilines[polyline.ULID] = graphicsPolyline;
            }
        }
    }
}
