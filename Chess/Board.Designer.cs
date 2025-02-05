namespace Chess
{
    partial class Board
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Board));
            this.PiecesImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // PiecesImages
            // 
            this.PiecesImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("PiecesImages.ImageStream")));
            this.PiecesImages.TransparentColor = System.Drawing.Color.Red;
            this.PiecesImages.Images.SetKeyName(0, "Bishop.bmp");
            this.PiecesImages.Images.SetKeyName(1, "BishopBlack.bmp");
            this.PiecesImages.Images.SetKeyName(2, "King.bmp");
            this.PiecesImages.Images.SetKeyName(3, "KingBlack.bmp");
            this.PiecesImages.Images.SetKeyName(4, "Knight.bmp");
            this.PiecesImages.Images.SetKeyName(5, "KnightBlack.bmp");
            this.PiecesImages.Images.SetKeyName(6, "Pawn.bmp");
            this.PiecesImages.Images.SetKeyName(7, "PawnBlack.bmp");
            this.PiecesImages.Images.SetKeyName(8, "Queen.bmp");
            this.PiecesImages.Images.SetKeyName(9, "QueenBlack.bmp");
            this.PiecesImages.Images.SetKeyName(10, "Rook.bmp");
            this.PiecesImages.Images.SetKeyName(11, "RookBlack.bmp");
            // 
            // Board
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Board";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList PiecesImages;
    }
}
