using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Bishop: Piece
    {
        public Bishop(Player player): base(player) {
            Value = 3;
            ImageIdx = 0;
        }
        public override List<Cell> GetStopSquares()
        {
            var cells = new List<Cell>();
            cells.AddRange(GetStopSquaresFromDir(-1, -1));
            cells.AddRange(GetStopSquaresFromDir(-1, 1));
            cells.AddRange(GetStopSquaresFromDir(1, -1));
            cells.AddRange(GetStopSquaresFromDir(1, 1));
            return cells;
        }
    }
}
