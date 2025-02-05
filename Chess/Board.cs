using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chess
{
    public partial class Board : UserControl
    {
        public static int N = 8;
        public Game Game;
        public Cell ActiveSquare;
        Piece activePiece;
        protected Piece ActivePiece
        {
            get { return activePiece; }
            set
            {
                activePiece = value;
                foreach (var cell in Game.Squares)
                {
                    cell.IsHighlighted = false;
                }
                if(activePiece != null)
                {
                    var moves=activePiece.GetMoves();
                    moves.ForEach(move => move.StopCell.IsHighlighted = true);
                }
                Invalidate();
            }
        }
        public Board()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        Cell CellAt(float x, float y)
        {
            var cellW = (float)Width / N;
            var cellH = (float)Height / N;
            y /= cellH;
            x /= cellW;
            if (x < 0 || y < 0 || x >= N || y >= N)
                return null;
            return Game.Squares[(int)x, (int)y];
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            var cell = CellAt(e.X, e.Y);
            var piece = cell.Piece;
            if (piece?.Player == Game.ActivePlayer)
            {
                ActiveSquare = cell;
                ActivePiece = piece;
                Invalidate();
            }
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (ActivePiece != null)
            {
                ActiveSquare = CellAt(e.X, e.Y);
                Invalidate();
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (ActivePiece != null && ActiveSquare.IsHighlighted)
            {
                var moves = ActivePiece.GetMoves();
                var move = moves.Find(x => x.StopCell == ActiveSquare);
                move.Execute();
                //ActivePiece.Square = ActiveSquare;
                Invalidate();
            }
            ActivePiece = null;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var cellW = (float)Width / N;
            var cellH = (float)Height / N;
            e.Graphics.ScaleTransform(cellW, cellH);
            var brush = new SolidBrush(ForeColor);
            for(int y = 0; y < N; y++)
                for(int x = 0; x < N; x++)
                {
                    var cellRect = new Rectangle(x, y, 1, 1);
                    brush.Color = (x + y) % 2 != 0 ? ForeColor : BackColor;

                    e.Graphics.FillRectangle(brush, cellRect);
                    if (Game != null)
                    {
                        var square = Game.Squares[x, y];
                        if(square.IsHighlighted)
                            e.Graphics.FillRectangle(Brushes.Yellow, cellRect);
                        var piece = square.Piece;
                        if (piece != null && piece != ActivePiece)
                            e.Graphics.DrawImage(PiecesImages.Images[piece.ImageIdx], cellRect);
                    }
                }
            if (ActivePiece != null && ActiveSquare != null)
            {
                var activeRect = new Rectangle(ActiveSquare.X, ActiveSquare.Y, 1, 1);
                e.Graphics.FillRectangle(Brushes.Red, activeRect);
                e.Graphics.DrawImage(PiecesImages.Images[ActivePiece.ImageIdx], activeRect);
            }
        }
    }
}
