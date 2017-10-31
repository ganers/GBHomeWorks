namespace BelieveOrNotBelieve
{
    partial class GameForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miExitGame = new System.Windows.Forms.ToolStripMenuItem();
            this.miAbautGame = new System.Windows.Forms.ToolStripMenuItem();
            this.miQstEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnTrue = new System.Windows.Forms.Button();
            this.btnFalse = new System.Windows.Forms.Button();
            this.labelQuestions = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelScores = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.miAbautGame,
            this.miQstEdit});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miNewGame,
            this.toolStripSeparator1,
            this.miExitGame});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // miNewGame
            // 
            this.miNewGame.Name = "miNewGame";
            this.miNewGame.Size = new System.Drawing.Size(181, 26);
            this.miNewGame.Text = "Новая";
            this.miNewGame.Click += new System.EventHandler(this.miNewGame_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(125, 6);
            // 
            // miExitGame
            // 
            this.miExitGame.Name = "miExitGame";
            this.miExitGame.Size = new System.Drawing.Size(128, 26);
            this.miExitGame.Text = "Выход";
            this.miExitGame.Click += new System.EventHandler(this.miExitGame_Click);
            // 
            // miAbautGame
            // 
            this.miAbautGame.Name = "miAbautGame";
            this.miAbautGame.Size = new System.Drawing.Size(116, 24);
            this.miAbautGame.Text = "О программе";
            this.miAbautGame.Click += new System.EventHandler(this.miAbautGame_Click);
            // 
            // miQstEdit
            // 
            this.miQstEdit.Name = "miQstEdit";
            this.miQstEdit.Size = new System.Drawing.Size(156, 24);
            this.miQstEdit.Text = "Редактор вопросов";
            this.miQstEdit.Click += new System.EventHandler(this.miQstEdit_Click);
            // 
            // btnTrue
            // 
            this.btnTrue.Location = new System.Drawing.Point(98, 200);
            this.btnTrue.Name = "btnTrue";
            this.btnTrue.Size = new System.Drawing.Size(75, 23);
            this.btnTrue.TabIndex = 2;
            this.btnTrue.Text = "Верю";
            this.btnTrue.UseVisualStyleBackColor = true;
            this.btnTrue.Click += new System.EventHandler(this.btnTrue_Click);
            // 
            // btnFalse
            // 
            this.btnFalse.Location = new System.Drawing.Point(366, 200);
            this.btnFalse.Name = "btnFalse";
            this.btnFalse.Size = new System.Drawing.Size(75, 23);
            this.btnFalse.TabIndex = 3;
            this.btnFalse.Text = "Не Верю";
            this.btnFalse.UseVisualStyleBackColor = true;
            this.btnFalse.Click += new System.EventHandler(this.btnFalse_Click);
            // 
            // labelQuestions
            // 
            this.labelQuestions.AutoSize = true;
            this.labelQuestions.Location = new System.Drawing.Point(12, 77);
            this.labelQuestions.Name = "labelQuestions";
            this.labelQuestions.Size = new System.Drawing.Size(0, 17);
            this.labelQuestions.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Очки";
            // 
            // labelScores
            // 
            this.labelScores.AutoSize = true;
            this.labelScores.Location = new System.Drawing.Point(60, 122);
            this.labelScores.Name = "labelScores";
            this.labelScores.Size = new System.Drawing.Size(0, 17);
            this.labelScores.TabIndex = 6;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 253);
            this.Controls.Add(this.labelScores);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelQuestions);
            this.Controls.Add(this.btnFalse);
            this.Controls.Add(this.btnTrue);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GameForm";
            this.Text = "Верю Не Верю!";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miNewGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miExitGame;
        private System.Windows.Forms.ToolStripMenuItem miAbautGame;
        private System.Windows.Forms.ToolStripMenuItem miQstEdit;
        private System.Windows.Forms.Button btnTrue;
        private System.Windows.Forms.Button btnFalse;
        private System.Windows.Forms.Label labelQuestions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelScores;
    }
}