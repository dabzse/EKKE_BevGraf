using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EKKE_BevGraf
{
    public static class GraphicsExtension
    {
        private static float Height;

        public static void SetParams(this Graphics g, float height)
        {
            Height = height;
        }

        public static void SetTransform(this Graphics g)
        {
            g.PageUnit = GraphicsUnit.Millimeter;
            g.TranslateTransform(0.0f, Height);
            g.ScaleTransform(1.0f, -1.0f);
        }

        public static void DrawPoint(this Graphics g, Pen pen, PointF point)
        {
            g.SetTransform();
            g.DrawEllipse(pen, point.X - 1, point.Y - 1, 2, 2);
            g.ResetTransform();
        }
    }
}
