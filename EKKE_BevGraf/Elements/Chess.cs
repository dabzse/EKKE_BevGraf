using System.Drawing;

namespace EKKE_BevGraf.Elements
{
    public class Chess
    {
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
