using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PolygonViewerApp.Models
{
    class XmlParser<T>
    {
        public static T ParseFile(string filename)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(T));  

            Dictionary<string, System.Windows.Shapes.Polyline> templistpoliline = new Dictionary<string, System.Windows.Shapes.Polyline>();

            T data;
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                data = (T)formatter.Deserialize(fs);    
            }
            return data;

            var test = new List<int>();
            var test2 = new HashSet<int>();

            var res = test[1];
        }
    }
}
