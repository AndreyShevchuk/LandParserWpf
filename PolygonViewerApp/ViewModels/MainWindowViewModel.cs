using DutyFier.Client.Wpf;
using Microsoft.Win32;
using PolygonViewerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PolygonViewerApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public UIElementCollection CanvasChildren { get; set; }
        public ObservableCollection<LandPlot> LandPlots {get;set;}
        private LandPlot selecLandPlot;
        public LandPlot SelecLandPlot { get { return selecLandPlot; } set { selecLandPlot = value;  OnPropertyChanged("SelecLandPlot"); } }
        public RelayCommands<UIElementCollection> GetUIElement { get; set; }
        public RelayCommands OpenFile { get; set; }

        public MainWindowViewModel()
        {
            GetUIElement = new RelayCommands<UIElementCollection>((obj) => CanvasChildren = obj, (obj) => true);
            OpenFile = new RelayCommands(ParseXmlFile);
        }
  
        private void ParseXmlFile()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "XML files (*.xml)|*.xml",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var data = XmlParser<UkrainianCadastralExchangeFile>.ParseFile(openFileDialog.FileName);
                PraseInfoLandsPlot praseInfoLandsPlot = new PraseInfoLandsPlot(data);
                LandPlots = new ObservableCollection<LandPlot>(praseInfoLandsPlot.GetLandPlots());
                CanvasChildren.Clear();
                CanvasChildren.AddRange(praseInfoLandsPlot.polilines.Values.ToList());
                AddMouseHandlr();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void AddMouseHandlr()
        {
            foreach (var item in LandPlots)
            {
                foreach (var poliline in item.Polylines)
                {

                    poliline.MouseLeave += (s, e) =>
                    {
                        LandPlot.stat = true;
                    };

                    poliline.MouseDown += (s, e) =>
                    {
                        if (LandPlot.stat)
                        {
                            LandPlot.stat = false;
                            if (SelecLandPlot != null)
                            {
                                foreach (var poliline2 in SelecLandPlot.Polylines)
                                {
                                    poliline2.Stroke = Brushes.Red;
                                }
                            }
                            SelecLandPlot = item;
                            foreach (var poliline2 in item.Polylines)
                            {
                                poliline2.Stroke = Brushes.Gray;
                            }
                        }
                    };
                }
            }
        }
    }
}
