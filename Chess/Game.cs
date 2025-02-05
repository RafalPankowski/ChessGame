using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public class Game
    {
        public Player Whites;
        public Player Blacks;
        public Player ActivePlayer;
        public Cell[,] Squares = new Cell[Board.N, Board.N];
        public List<Move> Moves = new List<Move>();
        public Game()
        {
            for(int y = 0; y < Board.N; y++)
            {
                for(int x = 0; x < Board.N; x++)
                {
                    var square = new Cell();
                    square.Game = this;
                    square.X = x;
                    square.Y = y;
                    Squares[x, y] = square;
                }
            }
            Restart();
        }

        public void Restart()
        {
            Whites = new Player();
            Blacks = new Player();
            Whites.Enemy = Blacks;
            Blacks.Enemy = Whites;
            ActivePlayer = Blacks;
            for (int i = 0; i < 2; i++)
            {
                for(int j = 0; j < ActivePlayer.Pieces.Count; j++)
                {
                    var piece = ActivePlayer.Pieces[j];
                    var x = j % Board.N;
                    var y = j / Board.N;
                    if (ActivePlayer == Whites)
                        y = Board.N - 1 - y;
                    else
                        piece.ImageIdx++;
                    piece.Square = Squares[x, y];
                }
                ActivePlayer = Whites;
            }
        }

        public void NextTurn()
        {
            ActivePlayer = ActivePlayer.Enemy;
        }
    }
}
