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

        public void InfoOnFormUpdate()
        {
            currentNum.Text = Convert.ToString(game.Current);
            labelStep.Text = Convert.ToString(game.Step);
        }

        public void InitNewGame()
        {
            Random rand = new Random();

            if (!Int32.TryParse(inMaxNum.Text, out int maxNum))
            {
                maxNum = 1000;
                inMaxNum.Text = "1000";
            }

            int finish = rand.Next(1, maxNum);
            game.InitGame(finish);
            numTarget.Text = Convert.ToString(finish);
            currentNum.Text = "1";
            labelStep.Text = "0";
        }

        public void CheckStatusGame()
        {
            if (game.isStop())
            {
                MessageBox.Show($"Перебор!\nЗагаданое числол: {game.Finish}\nВаше число: {game.Current}\nКол-во шагов: {game.Step}");
                InitNewGame();
            }
            if (game.isWin())
            {
                MessageBox.Show($"Вы победили!\nЗагаданое числол: {game.Finish}\nВаше число: {game.Current}\nКол-во шагов: {game.Step}");
                InitNewGame();
            }
        }

        public Form1()
        {
            InitializeComponent();
            InitNewGame();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addOne_Click(object sender, EventArgs e)
        {
            game.CurrentAddOne();
            CheckStatusGame();
            InfoOnFormUpdate();

        }

        public void startGame_Click(object sender, EventArgs e)
        {
            InitNewGame();
        }

        private void multiply2_Click(object sender, EventArgs e)
        {
            game.CurrentMultiplyBy2();
            CheckStatusGame();
            InfoOnFormUpdate();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            game.CurrentReset();
            CheckStatusGame();
            InfoOnFormUpdate();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            game.BackStep();
            InfoOnFormUpdate();
        }
    }
}
