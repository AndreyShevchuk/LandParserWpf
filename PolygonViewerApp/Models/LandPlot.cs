using PolygonViewerApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;

namespace PolygonViewerApp.Models
{

    class LandInfo : INotifyPropertyChanged
    {
        string cadastralZoneNumber;
        string cadastralQuarterNumber;
        string parcelID;
        string settlement;
        string region;
        string streetType;
        string streetName;
        string building;
        string measurementUnit;
        string size;

        public string CadastralZoneNumber { get { return cadastralZoneNumber; } set { cadastralZoneNumber = value; OnPropertyChanged("CadastralZoneNumber"); } }
        public string CadastralQuarterNumber { get { return cadastralQuarterNumber; } set { cadastralQuarterNumber = value; OnPropertyChanged("CadastralQuarterNumber"); } }
        public string ParcelID { get { return parcelID; }  set { parcelID = value; OnPropertyChanged("ParcelID"); }  }
        public string Settlement { get { return settlement; } set { settlement = value;  OnPropertyChanged("Settlement"); } }
        public string Region { get { return region; } set { region = value; OnPropertyChanged("Region"); }  }
        public string StreetType { get { return streetType; } set { streetType = value; OnPropertyChanged("StreetType"); } }
        public string StreetName { get { return streetName; } set { streetName = value; OnPropertyChanged("StreetName"); } }
        public string Building { get { return building; } set { building = value; OnPropertyChanged("Building"); } }
        public string MeasurementUnit { get { return measurementUnit; } set { measurementUnit = value; OnPropertyChanged("MeasurementUnit"); } }
        public string Size { get { return size; } set { size = value; OnPropertyChanged("Size"); } }

        public LandInfo(ParcelInfo parcelInfo, UkrainianCadastralExchangeFile data)
        {
            cadastralZoneNumber = data.InfoPart.CadastralZoneInfo.CadastralZoneNumber;
            cadastralQuarterNumber = data.InfoPart.CadastralZoneInfo.CadastralQuarters.CadastralQuarterInfo.CadastralQuarterNumber;
            parcelID = parcelInfo.ParcelMetricInfo.ParcelID;
            settlement = parcelInfo.ParcelLocationInfo.Settlement;
            region = parcelInfo.ParcelLocationInfo.Region;
            measurementUnit = parcelInfo.ParcelMetricInfo.Area.MeasurementUnit;
            size = parcelInfo.ParcelMetricInfo.Area.Size;
            
            try
            {
                building = parcelInfo.ParcelLocationInfo.ParcelAddress.Building;
            }
            catch (Exception)
            {
                building = "--";
            }

            try
            {
                streetType = parcelInfo.ParcelLocationInfo.ParcelAddress.StreetType;
            }
            catch (Exception)
            {
                streetType = "--";
            }
            
            try
            {
               streetName = parcelInfo.ParcelLocationInfo.ParcelAddress.StreetName;
            }
            catch (Exception)
            {
                streetName = "--";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

    class LandPlot
    {
        public static bool stat = true;
        public LandInfo LandInfo { get; set; }
        public ICollection<System.Windows.Shapes.Polyline> Polylines { get; set; }
        public LandPlot(ICollection<System.Windows.Shapes.Polyline> polylines, LandInfo landInfo)
        {
            Polylines = polylines;
            LandInfo = landInfo;
        }
    }
}
