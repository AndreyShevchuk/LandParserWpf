using System;
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
            foreach (var item in uIElements)
            {
                uIElementCollection.Add(item);
            }
        }
    }
}
