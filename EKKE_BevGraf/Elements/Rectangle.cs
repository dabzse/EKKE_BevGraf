using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKKE_BevGraf.Elements
{
    public class Rectangle
    {
        public VectorG StartPoint { get; }
        public VectorG EndPoint { get; }

        public Rectangle(VectorG startPoint, VectorG endPoint)
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
        }
    }
}
