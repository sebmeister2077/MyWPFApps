using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BBG_BigBallGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp;
        Graphics grp;
        Timer t;
        Ball b;
        int angle = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            b = new Ball(10, new Punct(450, 100), System.Drawing.Color.FromArgb(244,200,222), 0, 2, "RegBall");
            bmp = new Bitmap(500, 500);
            grp = Graphics.FromImage(bmp);
            t = new Timer();
            t.Enabled = true;
            t.Interval = 370;
            t.Tick += T_Tick;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            //TODO make last locations faded
            grp.Clear(Color.White);
            if (b.Position.X + Math.Cos(angle) * 10 > bmp.Width)
                angle = 180;
            if (b.Position.X + Math.Cos(angle) * 10 <0)
                angle = 0;
            b.Position = new Punct(b.Position + new Punct(Math.Cos(angle) * 10, 0));
            grp.DrawEllipse(Pens.Black, (float)b.X - 10, (float)b.Y-10, 20, 20);


            Stack<Punct> auxSt = new Stack<Punct>();
            Stack<Punct> thisSt =b.LastPositions;
            for(int i=b.CountPositions;i>0&&0<thisSt.Count; i--)
            {
                Punct p = thisSt.Peek();
                auxSt.Push(thisSt.Pop());
                Pen pe = new Pen(Color.FromArgb(200,Color.Blue));
                grp.DrawArc(pe, (float)p.X-10, (float)p.Y-10, 20, 20,angle+100+(b.CountPositions-i)*15, 170- (b.CountPositions - i) * 30);
            }
            while (auxSt.Count > 0)
                thisSt.Push(auxSt.Pop());
            pictureBox1.Image = bmp;
        }
    }
}
