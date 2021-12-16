using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Russian_Pereprava
{
    public partial class Rus_per : Form
    {
        Game game;
        public Rus_per()
        {
            InitializeComponent();
            this.game = new Game();
        }

        private void Go_btn_Click(object sender, EventArgs e)
        {
            game.Update(9999, 9999);
            Refresh();
        }

        private void Go_btn_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            game.Draw(e.Graphics);
        }

        private void Go_btn_MouseClick(object sender, MouseEventArgs e)
        {
            game.Update(e.X, e.Y);
            Refresh();
            if(game.CheckWin())
            {
                MessageBox.Show("V1");
                Application.Exit();
            }
        }
    }
}
