using System;
using System.Drawing;

namespace EKKE_BevGraf.Elements
{
    public class Ball
    {
        public int CurrPosX { get; private set; }
        public int CurrPosY { get; private set; }
        private int int_x;
        private int int_y;
        public Color Color { get; private set; }

        public Ball(int currPosX, int currPosY, int intX, int intY, Color color)
        {
            CurrPosX = currPosX;
            CurrPosY = currPosY;
            int_x = intX;
            int_y = intY;
            Color = color;
        }

        public void Move(int width, int height)
        {
            CurrPosX += int_x;
            CurrPosY += int_y;

            if (CurrPosX <= 0 || CurrPosX >= width - 20)
            {
                int_x *= -1;
                CurrPosX += int_x;
            }

            if (CurrPosY <= 0 || CurrPosY >= height - 20)
            {
                int_y *= -1;
                CurrPosY += int_y;
            }
        }

        public bool IsCollidingWith(Ball other)
        {
            int dx = CurrPosX - other.CurrPosX;
            int dy = CurrPosY - other.CurrPosY;
            int distance = (int)Math.Sqrt(dx * dx + dy * dy);
            return distance < 20; // the diameter of the ball
        }

        public void HandleCollision(Ball other)
        {
            int tempX = int_x;
            int tempY = int_y;
            int_x = other.int_x;
            int_y = other.int_y;
            other.int_x = tempX;
            other.int_y = tempY;
        }
    }
}
