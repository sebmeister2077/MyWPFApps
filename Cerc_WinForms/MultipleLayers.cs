using System;
using System.Drawing;
using System.Windows.Forms;
using ProjectViewModel;

namespace Cerc_WinForms
{
    public partial class MultipleLayers : Form
    {
        public MultipleLayers()
        {
            InitializeComponent();
        }
        Mainwindow parent;
        public MultipleLayers(Mainwindow _parent)
        {
            InitializeComponent();
            parent = _parent;
        }


        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Nr Puncte=" + trackBar1.Value;
            trackBar2.Maximum = (int)Math.Floor((decimal)trackBar1.Value / 2);
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
            label2.Text = "Linii=" + trackBar2.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Linii=" + trackBar2.Value;
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label3.Text="Distanta="+trackBar3.Value+"(units)";
            if (listBox1.SelectedItem!=null)
            {
                WindowsViewModel.SetLayer(int.Parse(listBox1.SelectedItem.ToString()), trackBar3.Value);
                pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
            }

        }
        private void Backtomain_Click(object sender, EventArgs e)
        {
            parent.Show();
            this.Close();
        }

        private void MultipleLayers_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackBar1.Minimum = int.Parse(listBox1.SelectedItem.ToString());
            WindowsViewModel.SetLayer(int.Parse(listBox1.SelectedItem.ToString()),trackBar3.Value);
            pictureBox1.Image=WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
        }

        private void btncloseall_Click(object sender, EventArgs e)
        {
            parent.Close();
            this.Close();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnReset.Visible = false;
            WindowsViewModel.ResetMuta(true);
            WindowsViewModel.SetLayer(int.Parse(listBox1.SelectedItem.ToString()), trackBar3.Value);
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
        }

        private void Btndecrement_Click(object sender, EventArgs e)
        {
            btnReset.Visible = true;
            WindowsViewModel.IncrementMuta(-0.2f);
            WindowsViewModel.SetLayer(int.Parse(listBox1.SelectedItem.ToString()), trackBar3.Value);
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            btnReset.Visible = true;
            WindowsViewModel.IncrementMuta(0.2f);
            WindowsViewModel.SetLayer(int.Parse(listBox1.SelectedItem.ToString()), trackBar3.Value);
            pictureBox1.Image = WindowsViewModel.Deseneaza(trackBar1.Value, trackBar2.Value);
        }
    }
}
