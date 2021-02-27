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
            this.txtratioReg = new System.Windows.Forms.TextBox();
            this.txtratioRep = new System.Windows.Forms.TextBox();
            this.txtratioMon = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trckbarSpeed)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.trckbarSpeed.Size = new System.Drawing.Size(104, 45);
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
            this.label2.Location = new System.Drawing.Point(1307, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Amount of Balls";
            // 
            // txbxballs
            // 
            this.txbxballs.Location = new System.Drawing.Point(1306, 93);
            this.txbxballs.Name = "txbxballs";
            this.txbxballs.Size = new System.Drawing.Size(90, 20);
            this.txbxballs.TabIndex = 5;
            this.txbxballs.Text = "20";
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(1306, 182);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(99, 42);
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
            this.groupBox1.Location = new System.Drawing.Point(1306, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(102, 57);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ball Type Ratio";
            // 
            // txtratioReg
            // 
            this.txtratioReg.Location = new System.Drawing.Point(6, 32);
            this.txtratioReg.Name = "txtratioReg";
            this.txtratioReg.Size = new System.Drawing.Size(27, 20);
            this.txtratioReg.TabIndex = 11;
            this.txtratioReg.Text = "6";
            // 
            // txtratioRep
            // 
            this.txtratioRep.Location = new System.Drawing.Point(38, 32);
            this.txtratioRep.Name = "txtratioRep";
            this.txtratioRep.Size = new System.Drawing.Size(28, 20);
            this.txtratioRep.TabIndex = 12;
            this.txtratioRep.Text = "3";
            // 
            // txtratioMon
            // 
            this.txtratioMon.Location = new System.Drawing.Point(72, 32);
            this.txtratioMon.Name = "txtratioMon";
            this.txtratioMon.Size = new System.Drawing.Size(27, 20);
            this.txtratioMon.TabIndex = 13;
            this.txtratioMon.Text = "1";
            // 
            // BBG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 801);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.txbxballs);
            this.Controls.Add(this.label2);
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
    }
}

