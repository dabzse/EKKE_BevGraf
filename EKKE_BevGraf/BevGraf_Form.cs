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
        private PointF curr_pos;
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

        private PointF PointToCanvas(PointF point)
        {
            return new PointF(px_mm(point.X), px_mm(canvas.Height - point.Y));
        }

        private float px_mm(float px)
        {
            return px / DPI * 25.4f;
        }
    }
}
