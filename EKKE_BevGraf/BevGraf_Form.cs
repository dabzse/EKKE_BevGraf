using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EKKE_BevGraf
{
    public partial class BevGraf_Form : Form
    {
        public BevGraf_Form()
        {
            InitializeComponent();
        }

        private List<Elements.Point> points = new List<Elements.Point>();
        private VectorG curr_pos;
        private int DrawIndex = -1;
        private bool is_drawing = false;

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            curr_pos = PointToCanvas(new PointF(e.X, e.Y));
            lbl_coordinates.Text = $"X: {e.X}, Y: {e.Y}";
            lbl_mm.Text = $"X: {curr_pos.X:F2}, Y: {curr_pos.Y:F2}";
        }

        private float DPI
        {
            get { return (float)CreateGraphics().DpiX; }
        }

        private VectorG PointToCanvas(PointF point)
        {
            return new VectorG(px_mm(point.X), px_mm(canvas.Height - point.Y));
        }

        private float px_mm(float px)
        {
            return px / DPI * 25.4f;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (is_drawing)
                {
                    switch (DrawIndex)
                    {
                        case 0:
                            points.Add(new Elements.Point(curr_pos));
                            break;
                    }
                    Refresh();
                }
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParams(px_mm(canvas.Height));

            if (points.Count > 0)
            {
                foreach (Elements.Point point in points)
                {
                    e.Graphics.DrawPoint(Pens.DarkBlue, point.Position.ToPointF);
                }
            }
        }

        private void btn_point_Click(object sender, EventArgs e)
        {
            DrawIndex = 0;
            is_drawing = true;
            Cursor = Cursors.Cross;
        }
    }
}
