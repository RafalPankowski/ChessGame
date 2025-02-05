using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Player
    {
        public List<Piece> Pieces = new List<Piece>();
        public King King;
        public Player Enemy;
        public Player() {
            new Rook(this);
            new Knight(this);
            new Bishop(this);
            new Queen(this);
            King = new King(this);
            new Bishop(this);
            new Knight(this);
            new Rook(this);
            for (int i = 0; i < Board.N; i++)
                new Pawn(this);
        }

        public List<Move> GetAllMoves()
        {
            var allMoves = new List<Move>();
            foreach (var piece in Pieces)
                allMoves.AddRange(piece.GetMoves());
            return allMoves;
        }
        public List<Move> EnemyMoves;
        //public List<Move> EnemyMoves
        //{
        //    get
        //    {
        //        if (enemyMoves == null)
        //        {
        //            enemyMoves = Enemy.GetAllMoves();
        //        }
        //        return enemyMoves;
        //    }
        //}
    }
}
