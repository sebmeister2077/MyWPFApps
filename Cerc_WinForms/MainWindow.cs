using System;
using System.Drawing;
using System.Windows.Forms;
using ProjectViewModel;

namespace Cerc_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            WindowsViewModel.SetLengths(pictureBox1.Width, pictureBox1.Height);
        }
        
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Nr Puncte=" + trackBar1.Value;
            if (trackBar1.Value <= trackBar2.Value)
                MessageBox.Show("Nu se pot trage mai multe linii decat uncte existante!");
            else
                pictureBox1.Image = WindowsViewModel. Deseneaza(trackBar1.Value, trackBar2.Value);
            trackBar2.Maximum = (int)Math.Floor((decimal)trackBar1.Value / 2);
            label2.Text = "Linii=" + trackBar2.Value;
        }
        
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Linii=" + trackBar2.Value;
            if (trackBar1.Value <= trackBar2.Value)
                MessageBox.Show("Nu se pot trage mai multe linii decat uncte existante!");
            else
                pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
        }

        private void btnMuta_Click(object sender, EventArgs e)
        {
            if (btnReset.Visible == false)
                btnReset.Visible = true;
            WindowsViewModel.IncrementMuta(0.5f);
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            WindowsViewModel.ResetMuta(true);
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
            btnReset.Visible = false;
        }
        private void btnmuta2_Click(object sender, EventArgs e)
        {
            if (btnreset2.Visible == false)
                btnreset2.Visible = true;
            WindowsViewModel.IncrementMuta(0, 7.0f);
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
        }
        private void btnreset2_Click(object sender, EventArgs e)
        {
            WindowsViewModel.ResetMuta(false, true);
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
            btnreset2.Visible = false;
        }
        private void btnCuloare_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                WindowsViewModel.ChangeColor(new Pen(colorDialog1.Color));
                pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            var newWindow = new MultipleLayers();
            newWindow.Show();
            this.Close();
        }
    }
}
