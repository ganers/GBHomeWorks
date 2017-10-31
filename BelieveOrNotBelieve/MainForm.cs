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
    public partial class MainForm : Form
    {
        //База данных вопросов
        TrueFalse database;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (database == null)
            {
                MessageBox.Show("Создайте новую базу данных", "Сообщение");
                return;
            }
            database.Add((database.Count + 1).ToString(), true);
            nudNumber.Maximum = database.Count;
            nudNumber.Value = database.Count;
        }

        private void miExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void miNew_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(sfd.FileName);
                database.Add("Введите вопрос", true);
                database.Save();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = 1;
                nudNumber.Value = 1;
            }
        }

        private void nudNumber_ValueChanged(object sender, EventArgs e)
        {
            tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
            cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string msg = "Вы уверены, что хотите удалить вопрос?";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(msg, "Error Detected in Input", buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                if (nudNumber.Maximum == 1 || database == null) return;
                database.Remove((int)nudNumber.Value-1);
                nudNumber.Maximum--;
                if (nudNumber.Value > 1) nudNumber.Value = nudNumber.Value;

                if (nudNumber.Value >= 2)
                {
                    tboxQuestion.Text = database[(int)nudNumber.Value - 1].Text;
                    cboxTrue.Checked = database[(int)nudNumber.Value - 1].TrueFalse;
                }                
            }

            
        }

        private void miSave_Click(object sender, EventArgs e)
        {
            if (database != null) database.Save();
            else MessageBox.Show("База данных не создана");
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                database = new TrueFalse(ofd.FileName);
                database.Load();
                nudNumber.Minimum = 1;
                nudNumber.Maximum = database.Count;
                nudNumber.Value = 1;
            }
        }

        private void btnSaveQuest_Click(object sender, EventArgs e)
        {
            database[(int)nudNumber.Value - 1].Text = tboxQuestion.Text;
            database[(int)nudNumber.Value - 1].TrueFalse = cboxTrue.Checked;
        }

        private void miSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "Questions DB files (*.qst)|*.qst|All files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (database != null) database.SaveAs(sfd.FileName);
                else MessageBox.Show("База данных не создана");
            }
        }

        private void miAbaut_Click(object sender, EventArgs e)
        {
            string msg = "Игра \"Верю не Верю!\"\nАвтор: Алексеев Андрей.\n";
            MessageBox.Show(msg);
        }
    }
}
