using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKKE_BevGraf.Elements
{
    public class Point
    {
        private VectorG position;
        // public VectorG Position { get; set; }
        public VectorG Position
        {
            get { return position; }
            set { position = value; }
        }

        private float thickness;
        // public float Thickness { get; set; }
        public float Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public Point()
        {
            this.Position = VectorG.Zero;
            this.Thickness = 0.0f;
        }

        public Point(VectorG position)
        {
            this.Position = position;
            this.Thickness = 0.0f;
        }

        public Point(VectorG position, float thickness)
        {
            this.Position = position;
            this.Thickness = thickness;
        }
    }
}
