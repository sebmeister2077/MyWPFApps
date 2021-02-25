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
        int WIDTH = 660, HEIGHT = 660;
        double secHand=300,minHand=210,hrHand=130;
        double mm, hh;
        decimal ss;
        //center
        int cx, cy;
        Bitmap bmp;
        Graphics grp;
        Queue<Point> lastCoords;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);
            lastCoords = new Queue<Point>();
            cx = WIDTH / 2;
            cy = HEIGHT / 2;
            ss = DateTime.Now.Second;
            mm = DateTime.Now.Minute;
            hh = DateTime.Now.Hour;
            this.BackColor = Color.White;
            t.Interval = 10;
            t.Tick += new EventHandler(this.t_Tick);
            t.Start();
        }
        private void t_Tick(object sender,EventArgs e)
        {
            ss+=0.01m;
            if(ss==60)
            { ss = 0;mm++; }
            if(mm==60)
            { mm = 0;hh++; }
            if (hh == 12)
                hh = 0;
            
            double[] handCoord = new double[2];
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);
            
            grp.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);

            grp.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(320, 2));
            grp.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(646, 332));
            grp.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(2, 323));
            grp.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(324, 640));

            handCoord = msCoord((double)ss, secHand);
            grp.DrawLine(new Pen(Color.Red, 1f), new Point(cx, cy), new Point((int)handCoord[0], (int)handCoord[1]));
            if (lastCoords.Count < 60)
                lastCoords.Enqueue(new Point((int)handCoord[0], (int)handCoord[1]));
            else
            {
                Queue<Point> auxQue = new Queue<Point>(lastCoords);
                while (auxQue.Count > 0)
                {
                    Point p = auxQue.Dequeue();
                    bmp.SetPixel(p.X,p.Y, Color.FromArgb(255-4 * auxQue.Count, 0, 0, 170)); 
                }
                lastCoords.Dequeue();
            }
            handCoord = msCoord(mm, minHand);
            grp.DrawLine(new Pen(Color.Black, 2f), new Point(cx, cy), new Point((int)handCoord[0], (int)handCoord[1]));

            handCoord = hrCoord(hh%12,mm, hrHand);
            grp.DrawLine(new Pen(Color.Gray, 3f), new Point(cx, cy), new Point((int)handCoord[0], (int)handCoord[1]));

            pictureBox1.Image = bmp;
            this.Text = "Analog Clock -  "+hh+":"+mm+":"+ss;
            grp.Dispose();

        }
        private double[] msCoord(double val, double hlen)
        {
            double[] coord = new double[2];
            val *= 6;
            if (val >= 0 && val <= 180)
                coord[0] = cx + (hlen * Math.Sin(Math.PI * val / 180));
            else
                coord[0] = cx - (hlen * -Math.Sin(Math.PI * val / 180));
            coord[1] = cy - (hlen * Math.Cos(Math.PI * val / 180));
            return coord;
        }
        private double[] hrCoord(double hval,double mval,double hlen)
        {
            double[] coord = new double[2];

            //each hour makes 30 degree
            //each minute makes 0.5 degree
            double val = ((hval * 30) + (mval * 0.5));
            if (val >= 0 && val <= 180)
                coord[0] = cx + (hlen * Math.Sin(Math.PI * val / 180));
            else
                coord[0] = cx - (hlen * -Math.Sin(Math.PI * val / 180));
            coord[1] = cy - (hlen * Math.Cos(Math.PI * val / 180));
            return coord;
        }

    }
}
