using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BelieveOrNotBelieve
{
    public partial class GameForm : Form
    {
        TrueFalse database;
        int currentQuestion = 1;
        int maxQuestion;
        int score = 0;


        public void initGame(string dbFName ="db.qst")
        {
            database = new TrueFalse(dbFName);
            database.Load();

            maxQuestion = database.Count;
            if (database.Count > 0)
            {
                labelQuestions.Text = database[currentQuestion].Text;
                //tboxQuestionGame.Text = database[currentQuestion].Text;
            }
            else
            {
                labelQuestions.Text = "В базе отсутствуют вопросы.";
                //tboxQuestionGame.Text = "В базе отсутствуют вопросы.";
            }
            labelScores.Text = score.ToString();

        }

        public GameForm()
        {
            InitializeComponent();

            initGame();

            
        }

        private void miExitGame_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTrue_Click(object sender, EventArgs e)
        {
            if (database[currentQuestion].TrueFalse)
            {
                MessageBox.Show("Правильно.");
                currentQuestion++;
                score++;
            }
            else
            {
                MessageBox.Show("Не правильно.");
                currentQuestion++;
            }
            initGame();
        }

        private void btnFalse_Click(object sender, EventArgs e)
        {
            if (!database[currentQuestion].TrueFalse)
            {
                MessageBox.Show("Правильно.");
                currentQuestion++;
                score++;
            }
            else
            {
                MessageBox.Show("Не правильно.");
                currentQuestion++;
            }
            initGame();
        }

        private void miNewGame_Click(object sender, EventArgs e)
        {
            currentQuestion = 1;
            score = 0;
            initGame();
        }

        private void miAbautGame_Click(object sender, EventArgs e)
        {
            string msg = "Игра \"Верю не Верю!\"\nАвтор: Алексеев Андрей.\n";
            MessageBox.Show(msg);
        }

        private void miQstEdit_Click(object sender, EventArgs e)
        {
            //Application.Run(new MainForm());
            MainForm edit = new MainForm();
            edit.Show();
        }
    }
}
