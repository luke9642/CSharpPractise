using System;

namespace App4_5
{
    public class GameBoard
    {
        public int Width { get; }
        public int Height { get; }
        
        public GameBoard(int width=5, int height=5)
        {
            Width = width;
            Height = height;
            var area = Width * Height;
            if (Width <= 0 || Height <= 0)
                throw new ArgumentException("Width or height are invalid.");
            if (area <= 10 || area > 50)
                throw new ArgumentException("Area of board is invalid.");
        }
    }
}