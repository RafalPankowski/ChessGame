using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Move
    {
        public Piece Piece;
        public Cell StartCell;
        public Cell StopCell;
        public Piece Capture;
        public void Execute()
        {
            Piece.Square = StopCell;
            if (Piece is King)
            {
                if (StopCell.X - StartCell.X == 2)
                {
                    var rook = StartCell.GetNeighbour(3, 0).Piece;
                    rook.Square = StopCell.GetNeighbour(-1, 0);
                }
                if (StopCell.X - StartCell.X == -2)
                {
                    var rook = StartCell.GetNeighbour(-4, 0).Piece;
                    rook.Square = StopCell.GetNeighbour(1, 0);
                }
            }
            if (Capture != null)
                Capture.Player.Pieces.Remove(Capture);
            Piece.MovesCount++;
            StopCell.Game.Moves.Add(this);
            StopCell.Game.NextTurn();
        }
        public void Undo()
        {
            StartCell.Game.NextTurn();
            StartCell.Game.Moves.RemoveAt(StartCell.Game.Moves.Count - 1);
            Piece.MovesCount--;
            if (Capture != null)
                Capture.Player.Pieces.Add(Capture);
            if (Piece is King)
            {
                if (StopCell.X - StartCell.X == 2)
                {
                    var rook = StopCell.GetNeighbour(-1, 0).Piece;
                    rook.Square = StartCell.GetNeighbour(3, 0);
                }
                if (StopCell.X - StartCell.X == -2)
                {
                    var rook = StopCell.GetNeighbour(1, 0).Piece;
                    rook.Square = StartCell.GetNeighbour(-4, 0);
                }
            }
            Piece.Square = StartCell;
        }
    }
}
