using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public abstract class Piece
    {
        public Player Player;
        public int Value;
        public int ImageIdx;
        public int MovesCount;
        Cell square;

        public Cell Square
        {
            get { return square; }
            set
            {
                if (square != null)
                    square.Piece = null;
                square = value;
                if (square != null)
                    square.Piece = this;
            }
        }
        public abstract List<Cell> GetStopSquares();
        public List<Cell> GetStopSquaresFromDir(int dirX, int dirY)
        {
            var cells= new List<Cell>();
            var cell = Square;
            do
            {
                cell = cell.GetNeighbour(dirX, dirY);
                cells.Add(cell);
            } while (cell !=null && cell.Piece == null);
            return cells;


        }
        public List<Move> GetMoves()
        {
            var moves=new List<Move>();
            var cells= GetStopSquares();
            foreach (var cell in cells)
            {
                if(cell==null) continue;
                var capture = cell.Piece;
                if(capture !=null && capture.Player==Player) continue;
                if (this is Pawn && Math.Abs(cell.X - Square.X) == 1)
                {
                    cell = Square.GetNeighbour()
                }
                var move = new Move();
                move.Piece = this;
                move.StartCell = Square;
                move.StopCell = cell;
                move.Capture = capture;
                moves.Add(move);
                
            }
            return moves;
        }

        public Piece(Player player)
        {
            Player = player;
            Player.Pieces.Add(this);

        }
        
    }
}
