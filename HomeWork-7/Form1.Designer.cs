namespace HomeWork_7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOne = new System.Windows.Forms.Button();
            this.lbl1 = new System.Windows.Forms.Label();
            this.numTarget = new System.Windows.Forms.Label();
            this.multiply2 = new System.Windows.Forms.Button();
            this.reset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.currentNum = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.startGame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelStep = new System.Windows.Forms.Label();
            this.inMaxNum = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(373, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(63, 24);
            this.toolStripMenuItem1.Text = "Меню";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // addOne
            // 
            this.addOne.Location = new System.Drawing.Point(12, 116);
            this.addOne.Name = "addOne";
            this.addOne.Size = new System.Drawing.Size(144, 23);
            this.addOne.TabIndex = 2;
            this.addOne.Text = "Добавить 1";
            this.addOne.UseVisualStyleBackColor = true;
            this.addOne.Click += new System.EventHandler(this.addOne_Click);
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(9, 38);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(125, 17);
            this.lbl1.TabIndex = 3;
            this.lbl1.Text = "Загаданое число:";
            // 
            // numTarget
            // 
            this.numTarget.AutoSize = true;
            this.numTarget.Location = new System.Drawing.Point(140, 38);
            this.numTarget.Name = "numTarget";
            this.numTarget.Size = new System.Drawing.Size(16, 17);
            this.numTarget.TabIndex = 4;
            this.numTarget.Text = "0";
            // 
            // multiply2
            // 
            this.multiply2.Location = new System.Drawing.Point(12, 147);
            this.multiply2.Name = "multiply2";
            this.multiply2.Size = new System.Drawing.Size(144, 23);
            this.multiply2.TabIndex = 8;
            this.multiply2.Text = "Умножить на 2";
            this.multiply2.UseVisualStyleBackColor = true;
            this.multiply2.Click += new System.EventHandler(this.multiply2_Click);
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(12, 176);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(144, 23);
            this.reset.TabIndex = 9;
            this.reset.Text = "Сбросить";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Текущее число:";
            // 
            // currentNum
            // 
            this.currentNum.AutoSize = true;
            this.currentNum.Location = new System.Drawing.Point(140, 65);
            this.currentNum.Name = "currentNum";
            this.currentNum.Size = new System.Drawing.Size(16, 17);
            this.currentNum.TabIndex = 11;
            this.currentNum.Text = "0";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 205);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(144, 23);
            this.btnBack.TabIndex = 12;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // startGame
            // 
            this.startGame.Location = new System.Drawing.Point(205, 116);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(144, 23);
            this.startGame.TabIndex = 14;
            this.startGame.Text = "Новая игра";
            this.startGame.UseVisualStyleBackColor = true;
            this.startGame.Click += new System.EventHandler(this.startGame_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "Кол-во шагов:";
            // 
            // labelStep
            // 
            this.labelStep.AutoSize = true;
            this.labelStep.Location = new System.Drawing.Point(304, 38);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(16, 17);
            this.labelStep.TabIndex = 16;
            this.labelStep.Text = "0";
            // 
            // inMaxNum
            // 
            this.inMaxNum.Location = new System.Drawing.Point(220, 88);
            this.inMaxNum.Name = "inMaxNum";
            this.inMaxNum.Size = new System.Drawing.Size(100, 22);
            this.inMaxNum.TabIndex = 17;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 253);
            this.Controls.Add(this.inMaxNum);
            this.Controls.Add(this.labelStep);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.currentNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.multiply2);
            this.Controls.Add(this.numTarget);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.addOne);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        public System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        public System.Windows.Forms.Button addOne;
        public System.Windows.Forms.Label lbl1;
        public System.Windows.Forms.Label numTarget;
        public System.Windows.Forms.Button multiply2;
        public System.Windows.Forms.Button reset;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label currentNum;
        public System.Windows.Forms.Button btnBack;
        public System.Windows.Forms.Button startGame;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelStep;
        private System.Windows.Forms.TextBox inMaxNum;
    }
}

