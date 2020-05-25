using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Windows.Controls
{
    public static class StaticMethodPoligon
    {
        public static void AddRange(this UIElementCollection uIElementCollection, ICollection<System.Windows.Shapes.Polyline> uIElements)
        {
            var hashtable = new Hashtable();
            foreach (var item in uIElements)
            {
                uIElementCollection.Add(item);
            }
        }

        public static void AddRange(this UIElementCollection uIElementCollection, ICollection<System.Windows.Shapes.Polygon> uIElements)
        {
            var hashtable = new Hashtable();
            foreach (var item in uIElements)
            {
                uIElementCollection.Add(item);
            }
        }
    }


    
}
