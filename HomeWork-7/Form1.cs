using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeWork_7
{
    public partial class Form1 : Form
    {
        Udvoitel game = new Udvoitel();

        public Form1()
        {
            InitializeComponent();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addOne_Click(object sender, EventArgs e)
        {
            game.CurrentAddOne();
            currentNum.Text = Convert.ToString(game.Current);
            labelStep.Text = Convert.ToString(game.Step);
        }

        public void startGame_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            int finish = rand.Next(1, 1000);
            game.InitGame(finish);
            numTarget.Text = Convert.ToString(finish);
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void multiply2_Click(object sender, EventArgs e)
        {
            game.CurrentMultiplyBy2();
            currentNum.Text = Convert.ToString(game.Current);
            labelStep.Text = Convert.ToString(game.Step);
        }

        private void reset_Click(object sender, EventArgs e)
        {
            game.CurrentReset();
            currentNum.Text = Convert.ToString(game.Current);
            labelStep.Text = Convert.ToString(game.Step);
        }
    }
}
