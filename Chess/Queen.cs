using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Queen: Piece
    {
        public Queen(Player player): base(player) {
            Value = 10;
            ImageIdx = 8;
        }
        public override List<Cell> GetStopSquares()
        {
            var cells = new List<Cell>();
            cells.AddRange(GetStopSquaresFromDir(-1, -1));
            cells.AddRange(GetStopSquaresFromDir(-1, 1));
            cells.AddRange(GetStopSquaresFromDir(1, -1));
            cells.AddRange(GetStopSquaresFromDir(1, 1));
            cells.AddRange(GetStopSquaresFromDir(0, -1));
            cells.AddRange(GetStopSquaresFromDir(0, 1));
            cells.AddRange(GetStopSquaresFromDir(-1, 0));
            cells.AddRange(GetStopSquaresFromDir(1, 0));
            return cells;
        }
    }
}
