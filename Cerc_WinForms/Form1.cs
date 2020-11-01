using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cerc_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics grp;
        Bitmap bmp;
        Pen myPen = Pens.Black;
        private static float muta = 0;
        private static float muta2 = 0;
        public class punct
        {
            public float x, y;

            public punct()
            {

            }
            public punct(int i, int n)
            {
                if (i % 2 == 0)
                {
                    x = 700 / 2 + 340 * (float)Math.Cos((float)360 / n * i * Math.PI / 180);
                    y = 700 / 2 - 340 * (float)Math.Sin((float)360 / n * i * Math.PI / 180);
                }
                else
                {
                    x = 700 / 2 + (340 - muta2) * (float)Math.Cos((float)360 / n * i * Math.PI / 180 + muta);
                    y = 700 / 2 - (340 - muta2) * (float)Math.Sin((float)360 / n * i * Math.PI / 180 + muta);
                }
            }
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = "Nr Puncte=" + trackBar1.Value;
            if (trackBar1.Value <= trackBar2.Value)
                MessageBox.Show("Nu se pot trage mai multe linii decat uncte existante!");
            else
                Deseneaza(trackBar1.Value, trackBar2.Value);
            trackBar2.Maximum = (int)Math.Floor((decimal)trackBar1.Value / 2);
            label2.Text = "Linii=" + trackBar2.Value;
        }
        private void Deseneaza(int n, int linii)
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);

            punct[] v = new punct[n];
            for (int i = 0; i < n; i++)
                v[i] = new punct(i, n);
            for (int i = 0; i < n; i++)
                grp.DrawEllipse(Pens.Blue, v[i].x, v[i].y, 2, 2);

            int decateori = linii, aux = 0;
            for (int i = 0; i < n; i++)
            {
                if (i < n - decateori)
                {
                    for (int j = 1; j <= decateori; j++)
                        grp.DrawLine(myPen, v[i].x, v[i].y, v[i + j].x, v[i + j].y);
                }
                else
                {
                    aux++;
                    for (int j = 1; j <= decateori - aux; j++)
                        grp.DrawLine(myPen, v[i].x, v[i].y, v[i + j].x, v[i + j].y);
                    for (int j = 1; j <= aux; j++)
                        grp.DrawLine(myPen, v[i].x, v[i].y, v[j - 1].x, v[j - 1].y);
                }
            }
            pictureBox1.Image = bmp;
        }
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label2.Text = "Linii=" + trackBar2.Value;
            if (trackBar1.Value <= trackBar2.Value)
                MessageBox.Show("Nu se pot trage mai multe linii decat uncte existante!");
            else
                Deseneaza(trackBar1.Value, trackBar2.Value);
        }

        private void btnMuta_Click(object sender, EventArgs e)
        {
            if (btnReset.Visible == false)
                btnReset.Visible = true;
            muta += 0.5f;
            Deseneaza(trackBar1.Value, trackBar2.Value);
        }
        private void btnReset_Click(object sender, EventArgs e)
        {
            muta = 0;
            Deseneaza(trackBar1.Value, trackBar2.Value);
            btnReset.Visible = false;
        }
        private void btnmuta2_Click(object sender, EventArgs e)
        {
            if (btnreset2.Visible == false)
                btnreset2.Visible = true;
            muta2 += 7f;
            if (muta2 >= 700)
                muta2 = 0;
            Deseneaza(trackBar1.Value, trackBar2.Value);
        }
        private void btnreset2_Click(object sender, EventArgs e)
        {
            muta2 = 0;
            Deseneaza(trackBar1.Value, trackBar2.Value);
            btnreset2.Visible = false;
        }
        private void btnCuloare_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Pen newPen;
                newPen = new Pen(colorDialog1.Color);
                myPen = newPen;
                Deseneaza(trackBar1.Value, trackBar2.Value);
            }
        }
    }
}
