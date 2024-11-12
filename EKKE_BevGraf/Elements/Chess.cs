using System;
using System.Drawing;
using System.Windows.Forms;

namespace EKKE_BevGraf.Elements
{
    public class Chess
    {
        private RadioButton rb_clear;
        private RadioButton rb_setup;
        private RadioButton rb_legal;
        private RadioButton rb_fishing;

        public Chess(RadioButton rb_clear, RadioButton rb_setup, RadioButton rb_legal, RadioButton rb_fishing)
        {
            this.rb_clear = rb_clear;
            this.rb_setup = rb_setup;
            this.rb_legal = rb_legal;
            this.rb_fishing = rb_fishing;

            // Set default selection
            rb_clear.Checked = true;

            // Add event handlers
            rb_clear.CheckedChanged += Rb_CheckedChanged;
            rb_setup.CheckedChanged += Rb_CheckedChanged;
            rb_legal.CheckedChanged += Rb_CheckedChanged;
            rb_fishing.CheckedChanged += Rb_CheckedChanged;
        }

        private void Rb_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_clear.Checked)
            {
                // Logic for clear
            }
            else if (rb_setup.Checked)
            {
                // Logic for setup
            }
            else if (rb_legal.Checked)
            {
                // Logic for legal
            }
            else if (rb_fishing.Checked)
            {
                // Logic for fishing
            }
        }

        public void DrawChess(Graphics g, int canvasHeight)
        {
            int rows = 8;
            int cols = 8;
            int cellSize = canvasHeight / rows;
            bool isWhite = true;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Brush brush = isWhite ? Brushes.White : Brushes.Black;
                    g.FillRectangle(brush, col * cellSize, row * cellSize, cellSize, cellSize);
                    isWhite = !isWhite;
                }
                isWhite = !isWhite;
            }

            // border
            using (Pen borderPen = new Pen(ColorTranslator.FromHtml("#1982e4"), 3))
            {
                g.DrawRectangle(borderPen, 0, 0, cols * cellSize, rows * cellSize);
            }

            // labels
            DrawLabels(g, cellSize, rows, cols);
        }

        private void DrawLabels(Graphics g, int cellSize, int rows, int cols)
        {
            Font font = new Font("Tahoma", 10, FontStyle.Bold);
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    string label = $"{(char)('a' + col)}{rows - row}";
                    Brush textBrush = ((row + col) % 2 == 0) ? Brushes.Black : Brushes.White;
                    SizeF textSize = g.MeasureString(label, font);

                    // Bottom-right corner
                    float xBottomRight = (col + 1) * cellSize - textSize.Width - 2;
                    float yBottomRight = (row + 1) * cellSize - textSize.Height - 2;
                    g.DrawString(label, font, textBrush, xBottomRight, yBottomRight);

                    // Top-left corner (upside down)
                    g.TranslateTransform(col * cellSize + textSize.Width + 2, row * cellSize + textSize.Height + 2);
                    g.RotateTransform(180);
                    g.DrawString(label, font, textBrush, 0, 0);
                    g.ResetTransform();
                }
            }
        }
    }
}
