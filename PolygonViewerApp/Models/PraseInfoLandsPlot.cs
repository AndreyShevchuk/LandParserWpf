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

        public System.Windows.Point СorectPoint;
        public Dictionary<string, System.Windows.Shapes.Polyline> Polilines { get; set; }
        public Dictionary<string, System.Windows.Point> Points { get; set; }

        public Dictionary<string, List <System.Windows.Point>> PolilinePoints { get; set; }
        
        public PraseInfoLandsPlot(UkrainianCadastralExchangeFile data)
        {
            this.data = data;
            Polilines = new Dictionary<string, System.Windows.Shapes.Polyline>();
            Points = new Dictionary<string, System.Windows.Point>();
            PolilinePoints = new Dictionary<string, List<System.Windows.Point>>();
            GetCortctPoints();
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
                    var tempPints = new List<System.Windows.Point>();

                    foreach (var item2 in item.MetricInfo.Externals.Boundary.Lines.Line)
                    {
                        tempBuferLines.Add(Polilines[item2.ULID]);
                    }
                    landsPlotsColections.Add(new LandPlot(tempBuferLines, LandInfo));
                }
            }
            return landsPlotsColections;
        }
        private void GetCortctPoints()
        {
            var minX = Double.MaxValue;
            var minY = Double.MaxValue;

            var maxX = Double.MinValue;
            var maxY = Double.MinValue;

            foreach (var point in data.InfoPart.MetricInfo.PointInfo.Point)
            {
                maxX = Math.Max(maxX, point.X);
                maxY = Math.Max(maxY, point.Y);

                minX = Math.Min(minX, point.X);
                minY = Math.Min(minY, point.Y);
            }
            
            СorectPoint = new System.Windows.Point((minX), (minY));

            foreach (var point in data.InfoPart.MetricInfo.PointInfo.Point)
            {
                Points[point.PN] = new System.Windows.Point(point.X - СorectPoint.X, point.Y - СorectPoint.Y);
            }
           
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
                    graphicsPolyline.Points.Add(Points[pointId]);
                    AddPointsInPolilinePoints(polyline.ULID, Points[pointId]);
                }
                Polilines[polyline.ULID] = graphicsPolyline;
            }
        }

        private void AddPointsInPolilinePoints(string key, System.Windows.Point point)
        {
            if (!PolilinePoints.ContainsKey(key))
            {
                PolilinePoints[key] = new List<System.Windows.Point>();
            }
            else
            {
                PolilinePoints[key].Add(point);
            }
        }
    }
}
