
namespace Bezier_Function
{
    partial class Examples
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
            this.picBox = new System.Windows.Forms.PictureBox();
            this.listBox = new System.Windows.Forms.ListBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.infoBox = new System.Windows.Forms.GroupBox();
            this.lblIsRandom = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxPoints = new System.Windows.Forms.RichTextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.infoBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Location = new System.Drawing.Point(24, 12);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(853, 537);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(883, 12);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(149, 108);
            this.listBox.TabIndex = 1;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listExamples_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(32)))), ((int)(((byte)(124)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(1038, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 38);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // infoBox
            // 
            this.infoBox.Controls.Add(this.txtbxPoints);
            this.infoBox.Controls.Add(this.label1);
            this.infoBox.Controls.Add(this.lblIsRandom);
            this.infoBox.Location = new System.Drawing.Point(883, 127);
            this.infoBox.Name = "infoBox";
            this.infoBox.Size = new System.Drawing.Size(149, 200);
            this.infoBox.TabIndex = 3;
            this.infoBox.TabStop = false;
            this.infoBox.Text = "Info";
            // 
            // lblIsRandom
            // 
            this.lblIsRandom.AutoSize = true;
            this.lblIsRandom.Location = new System.Drawing.Point(7, 20);
            this.lblIsRandom.Name = "lblIsRandom";
            this.lblIsRandom.Size = new System.Drawing.Size(110, 13);
            this.lblIsRandom.TabIndex = 0;
            this.lblIsRandom.Text = "Randomly Generated:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Points:";
            // 
            // txtbxPoints
            // 
            this.txtbxPoints.Location = new System.Drawing.Point(10, 50);
            this.txtbxPoints.Name = "txtbxPoints";
            this.txtbxPoints.Size = new System.Drawing.Size(122, 96);
            this.txtbxPoints.TabIndex = 2;
            this.txtbxPoints.Text = "";
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(124)))), ((int)(((byte)(28)))));
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Location = new System.Drawing.Point(1038, 56);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 38);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // Examples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(78)))), ((int)(((byte)(239)))));
            this.ClientSize = new System.Drawing.Size(1125, 563);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.infoBox);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.picBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Examples";
            this.Text = "Preview";
            this.Load += new System.EventHandler(this.Examples_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.infoBox.ResumeLayout(false);
            this.infoBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox infoBox;
        private System.Windows.Forms.Label lblIsRandom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtbxPoints;
        private System.Windows.Forms.Button btnLoad;
    }
}