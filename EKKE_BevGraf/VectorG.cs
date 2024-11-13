using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKKE_BevGraf
{
    public class VectorG
    {
        private float x, y, z;

        public VectorG(float x, float y)
        {
            this.X = x;
            this.Y = y;
            this.Z = 0.0f;
        }

        public VectorG(float x, float y, float z)
            : this(x, y)
        {
            this.Z = z;
        }

        public float X
        {
            get { return x; }
            set { x = value; }
        }

        public float Y
        {
            get { return y; }
            set { y = value; }
        }

        public float Z
        {
            get { return z; }
            set { z = value; }
        }

        public PointF ToPointF
        {
            get { return new PointF(x, y); }
        }

        public static VectorG Zero
        {
            get { return new VectorG(0.0f, 0.0f, 0.0f); }
        }

        public double DistanceFrom(VectorG v)
        {
            double dx = v.X - X;
            double dy = v.Y - Y;
            double dz = v.Z - Z;
            return Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }
}
