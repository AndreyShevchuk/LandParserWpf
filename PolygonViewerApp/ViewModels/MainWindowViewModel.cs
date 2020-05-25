using DutyFier.Client.Wpf;
using Microsoft.Win32;
using PolygonViewerApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace PolygonViewerApp.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        private Cursor cursor;
        private Cursor Cursor { get { return cursor; } set { cursor = value; } }

        public Action<UIElement, int> CanvasSetZindexPanel;
        public Func<UIElement, int> CanvasGetZindexPanel;
        public System.Windows.Point MouseLocation { get; set; }
        public UIElementCollection CanvasChildren { get; set; }
        public ObservableCollection<LandPlot> LandPlots { get; set; }
        private LandPlot selecLandPlot;
        public LandPlot SelecLandPlot { get { return selecLandPlot; } set { selecLandPlot = value; OnPropertyChanged("SelecLandPlot"); } }
        public RelayCommands<UIElementCollection> GetUIElement { get; set; }

        private RelayCommands<Object> enlargeCommands;
        public RelayCommands<Object> decreaseCommands;


        public RelayCommands<Object> EnlargeCommands
        {
            get
            {
                return enlargeCommands;
            }
            set
            {
                enlargeCommands = value;
            }
        }  
        public RelayCommands<Object> DecreaseCommands
        {
            get
            {
                return decreaseCommands;
            }
            set
            {
                enlargeCommands = value;
            }
        }
        public RelayCommands OpenFile { get; set; }
        public Scale Scale { get; set; }
        public ScaleCanvasParam ScaleCanvasParam { get;set;}
        public string SelectedScal { get; set; } = "";
        public ObservableCollection<string> ScallParam { get; set; }
        public Translate Translate { get; set; }


        public MainWindowViewModel()
        {
            ScallParam = new ObservableCollection<string>();
            ScallParam.Add("1:1");
            ScallParam.Add("1:100");
            ScallParam.Add("1:500");
            ScallParam.Add("1:1000");
            ScallParam.Add("1:2000");
            ScallParam.Add("1:5000");
            ScallParam.Add("1:10000");
            ScallParam.Add("1:25000");
            ScallParam.Add("1:50000");
            ScallParam.Add("1:100000");
            ScallParam.Add("1:200000");
            ScallParam.Add("1:300000");
            ScallParam.Add("1:500000");
            ScallParam.Add("1:1000000");

            this.Translate = new Translate();
            ScaleCanvasParam = new ScaleCanvasParam();
            Scale = new Scale();
            GetUIElement = new RelayCommands<UIElementCollection>((obj) => CanvasChildren = obj, (obj) => true);
            OpenFile = new RelayCommands(ParseXmlFile);
            enlargeCommands = new RelayCommands<Object>((obj) => Scale.Enlarge(1.3),(obj) => true);
            decreaseCommands = new RelayCommands<Object>((obj) => Scale.Decrease(1.3), (obj) => true);
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

                /////////////////////
                //CanvasChildren.AddRange(praseInfoLandsPlot.Polilines.Values.ToList());
                //AddMouseHandlr();


                //////////////////   Не працює коректно

                var tr = LandPlots.Select(e => e.Polygon).ToList();

                foreach (var item in LandPlots)
                {
                    item.Polygon.MouseUp += (s, e) =>
                    {
                        SelecLandPlot = item;
                        foreach (var item2 in LandPlots)
                        {
                            item2.Polygon.Fill = Brushes.White;
                        }
                        item.Polygon.Fill = Brushes.Gray;

                    };
                    
                }
                CanvasChildren.AddRange(tr);
            }
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
