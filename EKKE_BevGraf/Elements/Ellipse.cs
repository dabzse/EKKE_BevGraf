using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EKKE_BevGraf.Elements
{
    public class Ellipse
    {
        private VectorG center;
        private double majorAxis;
        private double minorAxis;
        private double rotation;
        private double startAngle;
        private double endAngle;
        private double thickness;

        public Ellipse(VectorG center, double majorAxis, double minorAxis)
        {
            this.Center = center;
            this.MajorAxis = majorAxis;
            this.MinorAxis = minorAxis;
            this.startAngle = 0.0;
            this.endAngle = 360.0;
            this.Rotation = 0.0;
            this.Thickness = 0.0;
        }

        public double Thickness
        {
            get { return thickness; }
            set { thickness = value; }
        }

        public double EndAngle
        {
            get { return endAngle; }
            set { endAngle = value; }
        }

        public double StartAngle
        {
            get { return startAngle; }
            set { startAngle = value; }
        }

        public double Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public double MinorAxis
        {
            get { return minorAxis; }
            set { minorAxis = value; }
        }

        public double MajorAxis
        {
            get { return majorAxis; }
            set { majorAxis = value; }
        }

        public VectorG Center
        {
            get { return center; }
            set { center = value; }
        }
    }
}
   