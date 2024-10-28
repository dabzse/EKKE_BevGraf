using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKKE_BevGraf.Elements
{
    public class Line
    {
		private VectorG startPoint;
        // public VectorG StartPoint { get; set; }
        public VectorG StartPoint
		{
			get { return startPoint; }
			set { startPoint = value; }
		}

        private VectorG endPoint;
        // public VectorG EndPoint { get; set; }
        public VectorG EndPoint
        {
            get { return endPoint; }
            set { endPoint = value; }
        }

        private float thickness;
        // public float Thickness { get; set; }
        public float Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public Line() : this(VectorG.Zero, VectorG.Zero) { }
        public Line(VectorG start, VectorG end)
        {
            this.StartPoint = start;
            this.EndPoint = end;
            this.Thickness = 0.0f;
        }
    }
}
