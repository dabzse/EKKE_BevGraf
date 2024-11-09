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
        private List<Elements.Rectangle> rectangles = new List<Elements.Rectangle>();
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
        }

        private void btn_balls_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            InitializeBalls();
            DrawIndex = 1;
            is_drawing = true;
            Cursor = Cursors.Default;
            ResetCollisionCounter();
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            DrawIndex = 2;
            is_drawing = true;
            Cursor = Cursors.Cross;
        }

        private void btn_rectangle_Click(object sender, EventArgs e)
        {
            ClearCanvas();
            DrawIndex = 3;
            is_drawing = true;
            Cursor = Cursors.Cross;
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
                            AddPoint(canvasPoint);
                            break;
                        case 1: // balls
                            AddBall(canvasPoint);
                            break;
                        case 2: // lines
                            AddLine(canvasPoint);
                            break;
                        case 3: // rectangles
                            AddRectangle(canvasPoint);
                            break;
                    }
                    canvas.Refresh();
                }
            }
        }

        private void AddPoint(VectorG canvasPoint)
        {
            var point = new Elements.Point
            {
                Position = canvasPoint
            };
            points.Add(point);
        }

        private void AddBall(VectorG canvasPoint)
        {
            balls.Add(new Elements.Ball((int)canvasPoint.X, (int)canvasPoint.Y, 2, 2, Color.Red));
            InitializeTimer();
        }

        private void AddLine(VectorG canvasPoint)
        {
            if (ClickNum == 1)
            {
                first_point = canvasPoint;
                points.Add(new Elements.Point { Position = first_point });
                ClickNum++;
            }
            else
            {
                lines.Add(new Elements.Line(first_point, canvasPoint));
                points.Add(new Elements.Point { Position = canvasPoint });
                first_point = canvasPoint;
            }
        }

        private void AddRectangle(VectorG canvasPoint)
        {
            switch (ClickNum)
            {
                case 1:
                    first_point = canvasPoint;
                    points.Add(new Elements.Point { Position = first_point });
                    ClickNum++;
                    break;
                case 2:
                    rectangles.Add(new Elements.Rectangle(first_point, canvasPoint));
                    points.Add(new Elements.Point { Position = canvasPoint });
                    first_point = curr_pos;
                    ClickNum = 1;
                    break;
            }
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
            InitializeTimer();
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
            if (DrawIndex == 1)
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
            }
            canvas.Invalidate();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetParams(px_mm(canvas.Height));
            Pen pen = new Pen(Color.DarkBlue, 0.1f);

            DrawPoints(e.Graphics);
            DrawBalls(e.Graphics);
            DrawLines(e.Graphics, pen);
            DrawRectangles(e.Graphics, pen);

            if (DrawIndex == 1)
            {
                lbl_collision.Visible = true;
            }
            else
            {
                lbl_collision.Visible = false;
            }
        }

        private void DrawPoints(Graphics graphics)
        {
            if (points.Count > 0)
            {
                foreach (var point in points)
                {
                    var canvasPoint = new PointF(mm_px(point.Position.X), mm_px(point.Position.Y));
                    graphics.FillEllipse(Brushes.DarkBlue, canvasPoint.X - 2, canvasPoint.Y - 2, 4, 4);
                }
            }
        }

        private void DrawBalls(Graphics graphics)
        {
            if (balls.Count > 0)
            {
                foreach (var ball in balls)
                {
                    using (Brush brush = new SolidBrush(ball.Color))
                    {
                        graphics.FillEllipse(brush, ball.CurrPosX, ball.CurrPosY, 20, 20);
                    }
                }
            }
        }

        private void DrawLines(Graphics graphics, Pen pen)
        {
            if (lines.Count > 0)
            {
                foreach (var line in lines)
                {
                    var startPoint = new PointF(mm_px(line.StartPoint.X), mm_px(line.StartPoint.Y));
                    var endPoint = new PointF(mm_px(line.EndPoint.X), mm_px(line.EndPoint.Y));
                    graphics.DrawLine(pen, startPoint, endPoint);
                }
            }
        }

        private void DrawRectangles(Graphics graphics, Pen pen)
        {
            if (rectangles.Count > 0)
            {
                foreach (var rectangle in rectangles)
                {
                    var startPoint = new PointF(mm_px(rectangle.StartPoint.X), mm_px(rectangle.StartPoint.Y));
                    var endPoint = new PointF(mm_px(rectangle.EndPoint.X), mm_px(rectangle.EndPoint.Y));
                    graphics.DrawRectangle(pen, Math.Min(startPoint.X, endPoint.X), Math.Min(startPoint.Y, endPoint.Y),
                        Math.Abs(startPoint.X - endPoint.X), Math.Abs(startPoint.Y - endPoint.Y));
                }
            }
        }

        private void ClearCanvas()
        {
            points.Clear();
            balls.Clear();
            lines.Clear();
            rectangles.Clear();
            canvas.Invalidate();
        }

        private float mm_px(float mm)
        {
            return mm * DPI / 25.4f;
        }

        private float px_mm(float px)
        {
            return px / DPI * 25.4f;
        }

        private VectorG PointToCanvas(PointF point)
        {
            // convert screen coordinates to canvas coordinates
            return new VectorG(px_mm(point.X), px_mm(point.Y));
        }

        private float DPI => (float)CreateGraphics().DpiX;

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

        private void ResetCollisionCounter()
        {
            collision_counter = 0;
            lbl_collision.Text = $"Collisions: {collision_counter}";
        }
    }
}
