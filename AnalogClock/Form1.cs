using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalogClock
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();
        int WIDTH = 660, HEIGHT = 660,secHand=300,minHand=210,hrHand=130;

        //center
        int cx, cy;
        Bitmap bmp;
        Graphics grp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);
            cx = WIDTH / 2;
            cy = HEIGHT / 2;

            this.BackColor = Color.White;
            t.Interval = 1000;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }
        private void t_Tick(object sender,EventArgs e)
        {
            grp = Graphics.FromImage(bmp);
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;
            
            int[] handCoord = new int[2];
            grp.Clear(Color.White);
            grp.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);

            grp.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(320, 2));
            grp.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(646, 332));
            grp.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(2, 323));
            grp.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(324, 640));

            handCoord = msCoord(ss, secHand);
            grp.DrawLine(new Pen(Color.Red, 1f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            handCoord = msCoord(mm, minHand);
            grp.DrawLine(new Pen(Color.Black, 2f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            handCoord = hrCoord(hh%12,mm, hrHand);
            grp.DrawLine(new Pen(Color.Gray, 3f), new Point(cx, cy), new Point(handCoord[0], handCoord[1]));

            pictureBox1.Image = bmp;
            this.Text = "Analog Clock -  "+hh+":"+mm+":"+ss;
            grp.Dispose();

        }
        private int[] msCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;
            if (val >= 0 && val <= 180)
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
            else
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
            coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            return coord;
        }
        private int[] hrCoord(int hval,int mval,int hlen)
        {
            int[] coord = new int[2];

            //each hour makes 30 degree
            //each minute makes 0.5 degree
            int val = (int)((hval * 30) + (mval * 0.5));
            if (val >= 0 && val <= 180)
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
            else
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
            coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            return coord;
        }

    }
}
