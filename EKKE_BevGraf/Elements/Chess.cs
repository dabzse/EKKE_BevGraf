using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EKKE_BevGraf.Elements
{
    public class Chess
    {
        private RadioButton rb_clear;
        private RadioButton rb_setup;
        private RadioButton rb_legal;
        private RadioButton rb_fishing;
        private Dictionary<string, Image> pieceImages;
        private Dictionary<string, string> initialPositions;

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

            // Load chess piece images
            LoadPieceImages();

            // Define initial positions
            DefineInitialPositions();
        }

        private void LoadPieceImages()
        {
            pieceImages = new Dictionary<string, Image>();
            string[] pieces = { "wk", "wq", "wr", "wb", "wn", "wp", "bk", "bq", "br", "bb", "bn", "bp" };
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "Assets", "Chess");
            foreach (var piece in pieces)
            {
                string path = Path.Combine(basePath, $"{piece}.png");
                if (File.Exists(path))
                {
                    pieceImages[piece] = Image.FromFile(path);
                    Console.WriteLine($"Loaded image: {path}");
                }
                else
                {
                    Console.WriteLine($"Image not found: {path}");
                }
            }
        }

        private void DefineInitialPositions()
        {
            initialPositions = new Dictionary<string, string>
            {
                { "a1", "wr" }, { "b1", "wn" }, { "c1", "wb" }, { "d1", "wq" }, { "e1", "wk" }, { "f1", "wb" }, { "g1", "wn" }, { "h1", "wr" },
                { "a2", "wp" }, { "b2", "wp" }, { "c2", "wp" }, { "d2", "wp" }, { "e2", "wp" }, { "f2", "wp" }, { "g2", "wp" }, { "h2", "wp" },
                { "a7", "bp" }, { "b7", "bp" }, { "c7", "bp" }, { "d7", "bp" }, { "e7", "bp" }, { "f7", "bp" }, { "g7", "bp" }, { "h7", "bp" },
                { "a8", "br" }, { "b8", "bn" }, { "c8", "bb" }, { "d8", "bq" }, { "e8", "bk" }, { "f8", "bb" }, { "g8", "bn" }, { "h8", "br" },
            };
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
                // Redraw the chessboard with pieces in initial positions
                // Assuming you have a reference to the canvas or form to trigger a redraw
                // For example: formInstance.Refresh();
                // Ensure the canvas is invalidated to trigger a redraw
                // Assuming you have a reference to the form or canvas
                // For example: formInstance.canvas.Invalidate();
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

            // Draw pieces if setup is selected
            if (rb_setup.Checked)
            {
                DrawPieces(g, cellSize);
            }
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

        private void DrawPieces(Graphics g, int cellSize)
        {
            foreach (var position in initialPositions)
            {
                string piece = position.Value;
                if (pieceImages.ContainsKey(piece))
                {
                    int col = position.Key[0] - 'a';
                    int row = 8 - int.Parse(position.Key[1].ToString());
                    g.DrawImage(pieceImages[piece], col * cellSize, row * cellSize, cellSize, cellSize);
                    Console.WriteLine($"Drawing piece: {piece} at {position.Key}");
                }
            }
        }
    }
}

