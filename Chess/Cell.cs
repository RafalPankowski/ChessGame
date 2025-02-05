using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Cell
    {
        public Game Game;
        public int X;
        public int Y;
        public Piece Piece;
        public bool IsHighlighted;
        public Cell GetNeighbour(int offsetX, int offsetY)
        {
            var x = X + offsetX;
            var y = Y + offsetY;
            if (x >= 0 && y >= 0 && x < Board.N && y < Board.N)
                return Game.Squares[x, y];
            return null;
        }
    }
}
