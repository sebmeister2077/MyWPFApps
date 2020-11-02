namespace Cerc_WinForms
{
    partial class Mainwindow
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
            this.btnMuta = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnreset2 = new System.Windows.Forms.Button();
            this.btnmuta2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCuloare = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnnext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMuta
            // 
            this.btnMuta.Location = new System.Drawing.Point(911, 36);
            this.btnMuta.Name = "btnMuta";
            this.btnMuta.Size = new System.Drawing.Size(82, 50);
            this.btnMuta.TabIndex = 44;
            this.btnMuta.Text = "Muta fiecare punct impar";
            this.btnMuta.UseVisualStyleBackColor = true;
            this.btnMuta.Click += new System.EventHandler(this.btnMuta_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(909, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 43;
            this.label4.Text = "Pt nr de pct pare";
            // 
            // btnreset2
            // 
            this.btnreset2.Location = new System.Drawing.Point(913, 201);
            this.btnreset2.Name = "btnreset2";
            this.btnreset2.Size = new System.Drawing.Size(82, 23);
            this.btnreset2.TabIndex = 42;
            this.btnreset2.Text = "Reset";
            this.btnreset2.UseVisualStyleBackColor = true;
            this.btnreset2.Visible = false;
            this.btnreset2.Click += new System.EventHandler(this.btnreset2_Click);
            // 
            // btnmuta2
            // 
            this.btnmuta2.Location = new System.Drawing.Point(912, 145);
            this.btnmuta2.Name = "btnmuta2";
            this.btnmuta2.Size = new System.Drawing.Size(82, 50);
            this.btnmuta2.TabIndex = 41;
            this.btnmuta2.Text = "Muta in interior fiecare pct impar";
            this.btnmuta2.UseVisualStyleBackColor = true;
            this.btnmuta2.Click += new System.EventHandler(this.btnmuta2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(908, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 40;
            this.label3.Text = "Pt nr de pct pare";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(912, 92);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(82, 23);
            this.btnReset.TabIndex = 39;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCuloare
            // 
            this.btnCuloare.Location = new System.Drawing.Point(911, 271);
            this.btnCuloare.Name = "btnCuloare";
            this.btnCuloare.Size = new System.Drawing.Size(84, 29);
            this.btnCuloare.TabIndex = 38;
            this.btnCuloare.Text = "Alta culoare";
            this.btnCuloare.UseVisualStyleBackColor = true;
            this.btnCuloare.Click += new System.EventHandler(this.btnCuloare_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(835, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Linii=";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(727, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Nr Puncte=";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(850, 58);
            this.trackBar2.Maximum = 0;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar2.Size = new System.Drawing.Size(45, 646);
            this.trackBar2.TabIndex = 35;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(730, 52);
            this.trackBar1.Maximum = 70;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar1.Size = new System.Drawing.Size(45, 646);
            this.trackBar1.TabIndex = 34;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, -2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(724, 706);
            this.pictureBox1.TabIndex = 33;
            this.pictureBox1.TabStop = false;
            // 
            // btnnext
            // 
            this.btnnext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnnext.Location = new System.Drawing.Point(901, 642);
            this.btnnext.Name = "btnnext";
            this.btnnext.Size = new System.Drawing.Size(94, 54);
            this.btnnext.TabIndex = 45;
            this.btnnext.Text = "Urmatoarea Fereastra";
            this.btnnext.UseVisualStyleBackColor = true;
            this.btnnext.Click += new System.EventHandler(this.btnnext_Click);
            // 
            // Mainwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 708);
            this.Controls.Add(this.btnnext);
            this.Controls.Add(this.btnMuta);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnreset2);
            this.Controls.Add(this.btnmuta2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCuloare);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Mainwindow";
            this.Text = "MainWindow";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMuta;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnreset2;
        private System.Windows.Forms.Button btnmuta2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCuloare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnnext;
    }
}

