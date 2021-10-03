
namespace Bezier_Function
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.canvas = new System.Windows.Forms.PictureBox();
            this.txtbxNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxPoints = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.chkbxVisibility = new System.Windows.Forms.CheckBox();
            this.chckStopClear = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dragPanel = new System.Windows.Forms.Panel();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chckDragMode = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbxSmoothness = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.dragPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.canvas.Location = new System.Drawing.Point(12, 46);
            this.canvas.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(853, 537);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.Click += new System.EventHandler(this.canvas_Click);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            // 
            // txtbxNumber
            // 
            this.txtbxNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(111)))), ((int)(((byte)(163)))));
            this.txtbxNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbxNumber.Location = new System.Drawing.Point(902, 72);
            this.txtbxNumber.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtbxNumber.Name = "txtbxNumber";
            this.txtbxNumber.Size = new System.Drawing.Size(125, 20);
            this.txtbxNumber.TabIndex = 1;
            this.txtbxNumber.TextChanged += new System.EventHandler(this.txtbxNumber_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(899, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number Of Points";
            // 
            // txtbxPoints
            // 
            this.txtbxPoints.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(111)))), ((int)(((byte)(163)))));
            this.txtbxPoints.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbxPoints.Location = new System.Drawing.Point(902, 160);
            this.txtbxPoints.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtbxPoints.Name = "txtbxPoints";
            this.txtbxPoints.Size = new System.Drawing.Size(125, 96);
            this.txtbxPoints.TabIndex = 3;
            this.txtbxPoints.Text = "";
            this.txtbxPoints.TextChanged += new System.EventHandler(this.txtbxPoints_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(899, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Points (x,y)";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(111)))), ((int)(((byte)(163)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(111)))), ((int)(((byte)(163)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.LawnGreen;
            this.button1.Location = new System.Drawing.Point(902, 262);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button1.Size = new System.Drawing.Size(125, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(923, 568);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(104, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "LinkToExplication";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // chkbxVisibility
            // 
            this.chkbxVisibility.AutoSize = true;
            this.chkbxVisibility.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkbxVisibility.Location = new System.Drawing.Point(902, 313);
            this.chkbxVisibility.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chkbxVisibility.Name = "chkbxVisibility";
            this.chkbxVisibility.Size = new System.Drawing.Size(100, 17);
            this.chkbxVisibility.TabIndex = 8;
            this.chkbxVisibility.Text = "See Every Point";
            this.chkbxVisibility.UseVisualStyleBackColor = true;
            this.chkbxVisibility.CheckedChanged += new System.EventHandler(this.chkbxVisibility_CheckedChanged);
            // 
            // chckStopClear
            // 
            this.chckStopClear.AutoSize = true;
            this.chckStopClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chckStopClear.Location = new System.Drawing.Point(902, 336);
            this.chckStopClear.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chckStopClear.Name = "chckStopClear";
            this.chckStopClear.Size = new System.Drawing.Size(102, 17);
            this.chckStopClear.TabIndex = 9;
            this.chckStopClear.Text = "Se All per ΔTime";
            this.chckStopClear.UseVisualStyleBackColor = true;
            this.chckStopClear.CheckedChanged += new System.EventHandler(this.chckStopClear_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(899, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 39);
            this.label3.TabIndex = 10;
            this.label3.Text = "Enter number of points \r\nand then click\r\n on canvas\r\n";
            // 
            // dragPanel
            // 
            this.dragPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(84)))), ((int)(((byte)(145)))));
            this.dragPanel.Controls.Add(this.btnMinimize);
            this.dragPanel.Controls.Add(this.btnClose);
            this.dragPanel.Controls.Add(this.pictureBox1);
            this.dragPanel.Location = new System.Drawing.Point(0, 0);
            this.dragPanel.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dragPanel.Name = "dragPanel";
            this.dragPanel.Size = new System.Drawing.Size(1048, 43);
            this.dragPanel.TabIndex = 11;
            this.dragPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseDown);
            this.dragPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dragPanel_MouseMove);
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Location = new System.Drawing.Point(949, 26);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(39, 14);
            this.btnMinimize.TabIndex = 2;
            this.btnMinimize.UseVisualStyleBackColor = false;
            this.btnMinimize.Click += new System.EventHandler(this.btnMinimize_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnClose.Location = new System.Drawing.Point(993, 5);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 35);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(37, 35);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // chckDragMode
            // 
            this.chckDragMode.AutoSize = true;
            this.chckDragMode.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chckDragMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chckDragMode.Location = new System.Drawing.Point(902, 492);
            this.chckDragMode.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.chckDragMode.Name = "chckDragMode";
            this.chckDragMode.Size = new System.Drawing.Size(106, 17);
            this.chckDragMode.TabIndex = 12;
            this.chckDragMode.Text = "Crazy Drag Mode";
            this.chckDragMode.UseVisualStyleBackColor = true;
            this.chckDragMode.CheckedChanged += new System.EventHandler(this.chckDragMode_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(902, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 26);
            this.label4.TabIndex = 13;
            this.label4.Text = "Smoothness \r\n(100 or above recommended)";
            // 
            // txtbxSmoothness
            // 
            this.txtbxSmoothness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(111)))), ((int)(((byte)(163)))));
            this.txtbxSmoothness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtbxSmoothness.Location = new System.Drawing.Point(905, 391);
            this.txtbxSmoothness.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.txtbxSmoothness.Name = "txtbxSmoothness";
            this.txtbxSmoothness.Size = new System.Drawing.Size(125, 20);
            this.txtbxSmoothness.TabIndex = 14;
            this.txtbxSmoothness.Text = "100";
            this.txtbxSmoothness.TextChanged += new System.EventHandler(this.txtbxSmoothness_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1049, 594);
            this.Controls.Add(this.txtbxSmoothness);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chckDragMode);
            this.Controls.Add(this.dragPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chckStopClear);
            this.Controls.Add(this.chkbxVisibility);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbxPoints);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbxNumber);
            this.Controls.Add(this.canvas);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bezier";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.dragPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.TextBox txtbxNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtbxPoints;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox chkbxVisibility;
        private System.Windows.Forms.CheckBox chckStopClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel dragPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.CheckBox chckDragMode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbxSmoothness;
    }
}

