using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using EKKE_BevGraf.Elements;

namespace EKKE_BevGraf
{
    public partial class BevGraf_Form : Form
    {
        private int collision_count = 0;
        private Label lbl_collisionCount;
        private List<Elements.Point> points = new List<Elements.Point>();
        private List<Ball> balls = new List<Ball>();
        private VectorG curr_pos;
        private int DrawIndex = -1;
        private bool is_drawing = false;
        private Timer timer;

        public BevGraf_Form()
        {
            InitializeComponent();
            InitializeCollisionCounter();
        }

        private void InitializeCollisionCounter()
        {
            lbl_collisionCount.Text = "Collisions: 0";
        }

        private void InitializeBalls()
        {
            balls.Clear();
            balls.Add(new Ball(100, 50, +2, +2, Color.Red));
            balls.Add(new Ball(300, 20, -2, +2, Color.Green));
            balls.Add(new Ball(700, 100, -2, -2, Color.Blue));
            balls.Add(new Ball(400, 150, +2, -2, Color.Black));
            balls.Add(new Ball(150, 400, -2, +2, Color.DarkBlue));
            balls.Add(new Ball(500, 300, +2, +2, Color.Purple));
            balls.Add(new Ball(600, 200, -2, -2, Color.Gold));
        }

        private void InitializeTimer()
        {
            if (timer == null)
            {
                timer = new Timer { Interval = 10 }; // movement
                timer.Tick += Timer_Tick;
            }
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (var ball in balls)
            {
                ball.Move(canvas.Width, canvas.Height);
            }

            for (int i = 0; i < balls.Count; i++)
            {
                for (int j = i + 1; j < balls.Count; j++)
                {
                    if (balls[i].IsCollidingWith(balls[j]))
                    {
                        balls[i].HandleCollision(balls[j]);
                        collision_count++;
                        lbl_collisionCount.Text = $"Collisions: {collision_count}";
                    }
                }
            }

            canvas.Invalidate();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            curr_pos = PointToCanvas(new PointF(e.X, e.Y));
            lbl_coordinates.Text = $"X: {e.X}, Y: {e.Y}";
            lbl_mm.Text = $"X: {curr_pos.X:F2}, Y: {curr_pos.Y:F2}";
        }

        private float DPI => (float)CreateGraphics().DpiX;

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
            if (e.Button == MouseButtons.Left && is_drawing && DrawIndex == 0)
            {
                points.Add(new Elements.Point(curr_pos));
                Refresh();
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParams(px_mm(canvas.Height));

            foreach (var point in points)
            {
                e.Graphics.DrawPoint(Pens.DarkBlue, point.Position.ToPointF);
            }

            foreach (var ball in balls)
            {
                using (Brush brush = new SolidBrush(ball.Color))
                {
                    e.Graphics.FillEllipse(brush, ball.CurrPosX, ball.CurrPosY, 20, 20);
                }
            }
        }

        private void btn_point_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            DrawIndex = 0;
            is_drawing = true;
            Cursor = Cursors.Cross;
        }

        private void btn_balls_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            InitializeBalls();
            InitializeTimer();
        }

        private void ClearCanvas()
        {
            points.Clear();
            balls.Clear();
            canvas.Invalidate();
        }
    }
}
