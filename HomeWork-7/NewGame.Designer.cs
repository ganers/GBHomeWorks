namespace HomeWork_7
{
    partial class NewGame
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
            this.numMax = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rBNoBack = new System.Windows.Forms.RadioButton();
            this.rBBack = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // numMax
            // 
            this.numMax.Location = new System.Drawing.Point(152, 31);
            this.numMax.Name = "numMax";
            this.numMax.Size = new System.Drawing.Size(100, 22);
            this.numMax.TabIndex = 0;
            this.numMax.Text = "1000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = "Максимальное\r\nзагадываемое\r\nчисло";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numMax);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 78);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rBBack);
            this.groupBox2.Controls.Add(this.rBNoBack);
            this.groupBox2.Location = new System.Drawing.Point(16, 108);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(254, 84);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // rBNoBack
            // 
            this.rBNoBack.AutoSize = true;
            this.rBNoBack.Location = new System.Drawing.Point(6, 21);
            this.rBNoBack.Name = "rBNoBack";
            this.rBNoBack.Size = new System.Drawing.Size(118, 21);
            this.rBNoBack.TabIndex = 0;
            this.rBNoBack.TabStop = true;
            this.rBNoBack.Text = "Честная игра";
            this.rBNoBack.UseVisualStyleBackColor = true;
            // 
            // rBBack
            // 
            this.rBBack.AutoSize = true;
            this.rBBack.Location = new System.Drawing.Point(6, 48);
            this.rBBack.Name = "rBBack";
            this.rBBack.Size = new System.Drawing.Size(133, 21);
            this.rBBack.TabIndex = 1;
            this.rBBack.TabStop = true;
            this.rBBack.Text = "Читерская игра";
            this.rBBack.UseVisualStyleBackColor = true;
            // 
            // NewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 211);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NewGame";
            this.Text = "NewGame";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox numMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rBBack;
        private System.Windows.Forms.RadioButton rBNoBack;
    }
}