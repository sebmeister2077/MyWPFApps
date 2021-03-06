namespace Grafuri
{
    partial class Form
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAddNode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnconn = new System.Windows.Forms.Button();
            this.txbxconn1 = new System.Windows.Forms.TextBox();
            this.txbxconn2 = new System.Windows.Forms.TextBox();
            this.lblError = new System.Windows.Forms.Label();
            this.lblExists = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(900, 500);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(590, 267);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(8, 8);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btnAddNode
            // 
            this.btnAddNode.Location = new System.Drawing.Point(918, 69);
            this.btnAddNode.Name = "btnAddNode";
            this.btnAddNode.Size = new System.Drawing.Size(113, 41);
            this.btnAddNode.TabIndex = 2;
            this.btnAddNode.Text = "Add Node";
            this.btnAddNode.UseVisualStyleBackColor = true;
            this.btnAddNode.Click += new System.EventHandler(this.btnAddNode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblExists);
            this.groupBox1.Controls.Add(this.lblError);
            this.groupBox1.Controls.Add(this.txbxconn2);
            this.groupBox1.Controls.Add(this.txbxconn1);
            this.groupBox1.Controls.Add(this.btnconn);
            this.groupBox1.Location = new System.Drawing.Point(918, 116);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(119, 94);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // btnconn
            // 
            this.btnconn.Location = new System.Drawing.Point(6, 19);
            this.btnconn.Name = "btnconn";
            this.btnconn.Size = new System.Drawing.Size(107, 23);
            this.btnconn.TabIndex = 0;
            this.btnconn.Text = "Add Connection";
            this.btnconn.UseVisualStyleBackColor = true;
            this.btnconn.Click += new System.EventHandler(this.btnconn_Click);
            // 
            // txbxconn1
            // 
            this.txbxconn1.Location = new System.Drawing.Point(6, 48);
            this.txbxconn1.Name = "txbxconn1";
            this.txbxconn1.Size = new System.Drawing.Size(33, 20);
            this.txbxconn1.TabIndex = 4;
            // 
            // txbxconn2
            // 
            this.txbxconn2.Location = new System.Drawing.Point(80, 48);
            this.txbxconn2.Name = "txbxconn2";
            this.txbxconn2.Size = new System.Drawing.Size(33, 20);
            this.txbxconn2.TabIndex = 5;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(45, 51);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(32, 13);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "Error!";
            this.lblError.Visible = false;
            // 
            // lblExists
            // 
            this.lblExists.AutoSize = true;
            this.lblExists.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F);
            this.lblExists.ForeColor = System.Drawing.Color.DarkRed;
            this.lblExists.Location = new System.Drawing.Point(18, 71);
            this.lblExists.Name = "lblExists";
            this.lblExists.Size = new System.Drawing.Size(84, 15);
            this.lblExists.TabIndex = 7;
            this.lblExists.Text = "Already exists!";
            this.lblExists.Visible = false;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 521);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnAddNode);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form";
            this.Text = "Form";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txbxconn2;
        private System.Windows.Forms.TextBox txbxconn1;
        private System.Windows.Forms.Button btnconn;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Label lblExists;
    }
}

