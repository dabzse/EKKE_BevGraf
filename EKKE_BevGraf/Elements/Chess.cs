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
        }
    }
}
