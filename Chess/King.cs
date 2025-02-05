using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class King: Piece
    {
        public King(Player player) : base(player)
        {
            Value = 100;
            ImageIdx = 2;
        }
        public override List<Cell> GetStopSquares()
        {
            var cells = new List<Cell>();
            cells.Add(Square.GetNeighbour(-1, 0));
            cells.Add(Square.GetNeighbour(-1, -1));
            cells.Add(Square.GetNeighbour(0, -1));
            cells.Add(Square.GetNeighbour(1, -1));
            cells.Add(Square.GetNeighbour(1, 0));
            cells.Add(Square.GetNeighbour(1, 1));
            cells.Add(Square.GetNeighbour(0, 1));
            cells.Add(Square.GetNeighbour(-1, 1));
            cells.Add(GetCastling(-1));
            cells.Add(GetCastling(+1));
            return cells;
        }

        public bool IsInCheck(Cell cell = null)
        {
            if (cell == null) cell = Square;
            return Player.EnemyMoves.Any(move => move.StopCell == cell);
        }

        public Cell GetCastling(int dir)
        {
            if (Player != Square.Game.ActivePlayer) return null;
            if (MovesCount > 0) return null;
            var offset = (dir == -1) ? 4 : 3;
            var rook = Square.GetNeighbour(offset * dir, 0).Piece;
            if (rook == null || rook.MovesCount > 0) return null;
            for (int i = 1; i < offset; i++)
                if (Square.GetNeighbour(i * dir, 0).Piece != null) return null;
            Player.EnemyMoves = Player.Enemy.GetAllMoves();
            for (int i = 0; i < 3; i++)
                if (IsInCheck(Square.GetNeighbour(i * dir, 0))) return null;
            return Square.GetNeighbour(2 * dir, 0);
        }
    }

}
