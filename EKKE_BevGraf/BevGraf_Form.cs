using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
// using EKKE_BevGraf.Elements;

namespace EKKE_BevGraf
{
    public partial class BevGraf_Form : Form
    {
        private List<Elements.Point> points = new List<Elements.Point>();
        private List<Elements.Ball> balls = new List<Elements.Ball>();
        private List<Elements.Line> lines = new List<Elements.Line>();
        private VectorG curr_pos;
        private VectorG first_point;
        private int DrawIndex = -1;
        private bool is_drawing = false;
        private uint ClickNum = 1;
        private Timer timer;
        private int collision_counter;

        private void btn_point_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            DrawIndex = 0;
            is_drawing = true;
            Cursor = Cursors.Cross;
            ResetCollisionCounter();
        }

        private void btn_balls_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            InitializeBalls();
            InitializeTimer();
            DrawIndex = 1;
            is_drawing = true;
            Cursor = Cursors.Default;
            ResetCollisionCounter();
        }

        private float mm_px(float mm)
        {
            return mm * DPI / 25.4f;
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            DrawIndex = 2;
            is_drawing = true;
            Cursor = Cursors.Cross;
            ResetCollisionCounter();
        }

        private void ResetCollisionCounter()
        {
            collision_counter = 0;
            lbl_collision.Text = $"Collisions: {collision_counter}";
        }
        public BevGraf_Form()
        {
            InitializeComponent();
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
            // convert screen coordinates to canvas coordinates
            return new VectorG(px_mm(point.X), px_mm(point.Y));
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
                    var canvasPoint = PointToCanvas(new PointF(e.X, e.Y));
                    switch (DrawIndex)
                    {
                        case 0: // points
                            points.Add(new Elements.Point(canvasPoint));
                            break;
                        case 1: // balls
                            // maybe needed for future use
                            break;
                        case 2: // lines
                            switch (ClickNum)
                            {
                                case 1:
                                    first_point = canvasPoint;
                                    points.Add(new Elements.Point(first_point));
                                    ClickNum++;
                                    break;
                                case 2:
                                    lines.Add(new Elements.Line(first_point, canvasPoint));
                                    points.Add(new Elements.Point(canvasPoint));
                                    first_point = curr_pos;
                                    break;
                            }
                            break;
                    }
                    canvas.Refresh();
                }
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParams(px_mm(canvas.Height));
            Pen pen = new Pen(Color.DarkBlue, 0.1f);

            if (points.Count > 0)
            {
                foreach (var point in points)
                {
                    var canvasPoint = new PointF(mm_px(point.Position.X), mm_px(point.Position.Y));
                    e.Graphics.FillEllipse(Brushes.DarkBlue, canvasPoint.X - 2, canvasPoint.Y - 2, 4, 4);
                }
            }

            if (balls.Count > 0)
            {
                foreach (var ball in balls)
                {
                    using (Brush brush = new SolidBrush(ball.Color))
                    {
                        e.Graphics.FillEllipse(brush, ball.CurrPosX, ball.CurrPosY, 20, 20);
                    }
                }
            }

            if (lines.Count > 0)
            {
                foreach (var line in lines)
                {
                    var startPoint = new PointF(mm_px(line.StartPoint.X), mm_px(line.StartPoint.Y));
                    var endPoint = new PointF(mm_px(line.EndPoint.X), mm_px(line.EndPoint.Y));
                    e.Graphics.DrawLine(pen, startPoint, endPoint);
                }
            }
        }


        private void ClearCanvas()
        {
            points.Clear();
            balls.Clear();
            lines.Clear();
            canvas.Invalidate();
        }

        private void InitializeBalls()
        {
            balls.Clear();
            balls.Add(new Elements.Ball(100, 50, +2, +2, Color.Red));
            balls.Add(new Elements.Ball(300, 20, -2, +2, Color.Green));
            balls.Add(new Elements.Ball(700, 100, -2, -2, Color.Blue));
            balls.Add(new Elements.Ball(400, 150, +2, -2, Color.Black));
            balls.Add(new Elements.Ball(150, 400, -2, +2, Color.DarkBlue));
            balls.Add(new Elements.Ball(500, 300, +2, +2, Color.Purple));
            balls.Add(new Elements.Ball(600, 200, -2, -2, Color.Gold));
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
                        collision_counter++;
                    }
                }
            }

            lbl_collision.Text = $"Collisions: {collision_counter}";
            canvas.Invalidate();
        }
    }
}
