using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public class Knight: Piece
    {
        public Knight(Player player): base(player) {
            Value = 3;
            ImageIdx = 4;
        }
        public override List<Cell> GetStopSquares()
        {
            var cells = new List<Cell>();
            cells.Add(Square.GetNeighbour(-2, -1));
            cells.Add(Square.GetNeighbour(-2, 1));
            cells.Add(Square.GetNeighbour(-1, -2));
            cells.Add(Square.GetNeighbour(1, -2));
            cells.Add(Square.GetNeighbour(2, -1));
            cells.Add(Square.GetNeighbour(2, 1));
            cells.Add(Square.GetNeighbour(-1, 2));
            cells.Add(Square.GetNeighbour(1, 2));
            return cells;
        }
    }
}
