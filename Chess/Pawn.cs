using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Pawn: Piece
    {
        public Pawn(Player player) : base(player)
        {
            Value = 1;
            ImageIdx = 6;
        }
        public override List<Cell> GetStopSquares()
        {
            var cells = new List<Cell>();
            var dir = Player == Square.Game.Blacks ? 1 : -1;
            var cell=Square.GetNeighbour(0, dir);
            if (cell.Piece == null)
            {
                cells.Add(cell);
                if(MovesCount==0)
                {
                    cell = cell.GetNeighbour(0, dir);
                    if (cell.Piece == null)
                        cells.Add(cell);
                }
            }           
            cell=Square.GetNeighbour(1, dir);
            if (cell != null && cell.Piece!=null)
                cells.Add(cell);
            cell = Square.GetNeighbour(-1, dir);
            if (cell != null && cell.Piece != null)
                cells.Add(cell);
            return cells;
        }
    }
}
