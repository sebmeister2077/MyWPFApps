namespace BBG_BigBallGame
{
    partial class BBG
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.trckbarSpeed = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxballs = new System.Windows.Forms.TextBox();
            this.btnreset = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtratioMon = new System.Windows.Forms.TextBox();
            this.txtratioRep = new System.Windows.Forms.TextBox();
            this.txtratioReg = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnGenMode = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txbxMon = new System.Windows.Forms.TextBox();
            this.txbxRep = new System.Windows.Forms.TextBox();
            this.txbxReg = new System.Windows.Forms.TextBox();
            this.rbtnCountMode = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.ChckboxCollide = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(1300, 800);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(263, 254);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1300, 800);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // trckbarSpeed
            // 
            this.trckbarSpeed.LargeChange = 3;
            this.trckbarSpeed.Location = new System.Drawing.Point(1306, 29);
            this.trckbarSpeed.Minimum = 1;
            this.trckbarSpeed.Name = "trckbarSpeed";
            this.trckbarSpeed.Size = new System.Drawing.Size(134, 45);
            this.trckbarSpeed.TabIndex = 2;
            this.trckbarSpeed.Value = 10;
            this.trckbarSpeed.Scroll += new System.EventHandler(this.trckbarSpeed_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1307, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Simulation Speed";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Amount of Balls";
            // 
            // txbxballs
            // 
            this.txbxballs.Enabled = false;
            this.txbxballs.Location = new System.Drawing.Point(9, 60);
            this.txbxballs.Name = "txbxballs";
            this.txbxballs.Size = new System.Drawing.Size(90, 20);
            this.txbxballs.TabIndex = 5;
            this.txbxballs.Text = "14";
            this.txbxballs.TextChanged += new System.EventHandler(this.txbxballs_TextChanged);
            // 
            // btnreset
            // 
            this.btnreset.Font = new System.Drawing.Font("Arial", 13.25F);
            this.btnreset.Location = new System.Drawing.Point(1306, 400);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(134, 42);
            this.btnreset.TabIndex = 6;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = true;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Reg";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rep";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Mon";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtratioMon);
            this.groupBox1.Controls.Add(this.txtratioRep);
            this.groupBox1.Controls.Add(this.txtratioReg);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(9, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 57);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ball Type Ratio";
            // 
            // txtratioMon
            // 
            this.txtratioMon.Enabled = false;
            this.txtratioMon.Location = new System.Drawing.Point(72, 32);
            this.txtratioMon.Name = "txtratioMon";
            this.txtratioMon.Size = new System.Drawing.Size(27, 20);
            this.txtratioMon.TabIndex = 13;
            this.txtratioMon.Text = "1";
            this.txtratioMon.TextChanged += new System.EventHandler(this.txtratioMon_TextChanged);
            // 
            // txtratioRep
            // 
            this.txtratioRep.Enabled = false;
            this.txtratioRep.Location = new System.Drawing.Point(38, 32);
            this.txtratioRep.Name = "txtratioRep";
            this.txtratioRep.Size = new System.Drawing.Size(28, 20);
            this.txtratioRep.TabIndex = 12;
            this.txtratioRep.Text = "3";
            this.txtratioRep.TextChanged += new System.EventHandler(this.txtratioRep_TextChanged);
            // 
            // txtratioReg
            // 
            this.txtratioReg.Enabled = false;
            this.txtratioReg.Location = new System.Drawing.Point(6, 32);
            this.txtratioReg.Name = "txtratioReg";
            this.txtratioReg.Size = new System.Drawing.Size(27, 20);
            this.txtratioReg.TabIndex = 11;
            this.txtratioReg.Text = "6";
            this.txtratioReg.TextChanged += new System.EventHandler(this.txtratioReg_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnGenMode);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.txbxballs);
            this.groupBox2.Location = new System.Drawing.Point(1306, 68);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 149);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Random Generation Mode";
            // 
            // rbtnGenMode
            // 
            this.rbtnGenMode.AutoSize = true;
            this.rbtnGenMode.Location = new System.Drawing.Point(6, 28);
            this.rbtnGenMode.Name = "rbtnGenMode";
            this.rbtnGenMode.Size = new System.Drawing.Size(14, 13);
            this.rbtnGenMode.TabIndex = 12;
            this.rbtnGenMode.TabStop = true;
            this.rbtnGenMode.UseVisualStyleBackColor = true;
            this.rbtnGenMode.CheckedChanged += new System.EventHandler(this.rbtnGenMode_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txbxMon);
            this.groupBox3.Controls.Add(this.txbxRep);
            this.groupBox3.Controls.Add(this.txbxReg);
            this.groupBox3.Controls.Add(this.rbtnCountMode);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(1306, 223);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(134, 100);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fixed Ball Count Mode";
            // 
            // txbxMon
            // 
            this.txbxMon.Location = new System.Drawing.Point(75, 60);
            this.txbxMon.Name = "txbxMon";
            this.txbxMon.Size = new System.Drawing.Size(27, 20);
            this.txbxMon.TabIndex = 16;
            this.txbxMon.Text = "1";
            this.txbxMon.TextChanged += new System.EventHandler(this.txbxMon_TextChanged);
            // 
            // txbxRep
            // 
            this.txbxRep.Location = new System.Drawing.Point(42, 60);
            this.txbxRep.Name = "txbxRep";
            this.txbxRep.Size = new System.Drawing.Size(27, 20);
            this.txbxRep.TabIndex = 15;
            this.txbxRep.Text = "3";
            this.txbxRep.TextChanged += new System.EventHandler(this.txbxRep_TextChanged);
            // 
            // txbxReg
            // 
            this.txbxReg.Location = new System.Drawing.Point(9, 60);
            this.txbxReg.Name = "txbxReg";
            this.txbxReg.Size = new System.Drawing.Size(27, 20);
            this.txbxReg.TabIndex = 14;
            this.txbxReg.Text = "7";
            this.txbxReg.TextChanged += new System.EventHandler(this.txbxReg_TextChanged);
            // 
            // rbtnCountMode
            // 
            this.rbtnCountMode.AutoSize = true;
            this.rbtnCountMode.Checked = true;
            this.rbtnCountMode.Location = new System.Drawing.Point(9, 28);
            this.rbtnCountMode.Name = "rbtnCountMode";
            this.rbtnCountMode.Size = new System.Drawing.Size(14, 13);
            this.rbtnCountMode.TabIndex = 13;
            this.rbtnCountMode.TabStop = true;
            this.rbtnCountMode.UseVisualStyleBackColor = true;
            this.rbtnCountMode.CheckedChanged += new System.EventHandler(this.rbtnCountMode_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(72, 44);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Mon";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Rep";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Reg";
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.btnPauseResume.ForeColor = System.Drawing.Color.Red;
            this.btnPauseResume.Location = new System.Drawing.Point(1306, 352);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(134, 42);
            this.btnPauseResume.TabIndex = 14;
            this.btnPauseResume.Text = "Pause";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // ChckboxCollide
            // 
            this.ChckboxCollide.AutoSize = true;
            this.ChckboxCollide.Location = new System.Drawing.Point(1306, 329);
            this.ChckboxCollide.Name = "ChckboxCollide";
            this.ChckboxCollide.Size = new System.Drawing.Size(148, 17);
            this.ChckboxCollide.TabIndex = 15;
            this.ChckboxCollide.Text = "MakeAllBallsCollide (Beta)";
            this.ChckboxCollide.UseVisualStyleBackColor = true;
            this.ChckboxCollide.MouseHover += new System.EventHandler(this.ChckboxCollide_MouseHover);
            // 
            // BBG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1452, 801);
            this.Controls.Add(this.ChckboxCollide);
            this.Controls.Add(this.btnPauseResume);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trckbarSpeed);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox);
            this.Name = "BBG";
            this.Text = "BBG";
            this.Load += new System.EventHandler(this.BBG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarSpeed)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar trckbarSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbxballs;
        private System.Windows.Forms.Button btnreset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtratioMon;
        private System.Windows.Forms.TextBox txtratioRep;
        private System.Windows.Forms.TextBox txtratioReg;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnGenMode;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txbxMon;
        private System.Windows.Forms.TextBox txbxRep;
        private System.Windows.Forms.TextBox txbxReg;
        private System.Windows.Forms.RadioButton rbtnCountMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPauseResume;
        private System.Windows.Forms.CheckBox ChckboxCollide;
    }
}

