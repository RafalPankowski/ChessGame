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
    public partial class Form1 : Form
    {
        Game Game = new Game();

        public Form1()
        {
            InitializeComponent();
            board1.Game = Game;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Game.Moves.Count > 0)
            {
                Game.Moves.Last().Undo();
                board1.Invalidate();
            }
        }
    }
}
