
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BBG_BigBallGame
{
    public partial class BBG : Form
    {
        const double PI = Math.PI;
        static Random rnd = new Random();
        Timer t;
        private int regular, repelent, monster;
        List<Ball> lista;
        Bitmap bmp;
        Graphics grp;
        public BBG()
        {
            InitializeComponent();
        }
        private void BBG_Load(object sender, EventArgs e)
        {
            Initialize(15);//amount of balls as parameter
            Start();
        }

        private void Initialize(int n)
        {
            lista = new List<Ball>();
            bmp = new Bitmap(1300, 800);
            regular = 0;
            repelent = 0;
            monster = 0;
            while (n-- > 0)
            {
                Ball b = new Ball(n+1);
                b.Raza = (5 - Math.Log((rnd.Next() % 20+2) * 3))*6+2;//higher chance for smaller balls spawning
                b.Position = new Punct(rnd.Next() % 1250 + 25, rnd.Next() % 750 + 25);
                b.Color = Color.FromArgb(200,(byte)(rnd.Next() % 255), (byte)(rnd.Next() % 255), (byte)(rnd.Next() % 255));
                b.Angle = rnd.Next() % 361 - 181;//interval: [-180,180]
                b.Speed = (rnd.Next() % 5)*3 + 4;
                int aux = rnd.Next() % 9;
                if (aux == 0)
                    b.Type = "MonBall";// sanse: 1/9
                else
                    if (aux < 4)
                { b.Type = "RepBall"; repelent++; }//  3/9
                else
                { b.Type = "RegBall"; regular++; }//   5/9
                lista.Add(b);
            }
        }
        private void Start()
        {
            t = new Timer();
            t.Interval = 200;
            t.Tick += T_Tick;
            t.Enabled = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (regular<=1)
            { t.Stop(); MessageBox.Show("Simulare incheiata."); }
            else
            {
                foreach (var bila in lista.ToList())
                {
                    if (bila.Raza < 1)
                    { lista.Remove(bila); continue; }
                    double nextmove = Math.Sin(bila.Angle * PI / 180) * bila.Speed + bila.Y;
                    if (nextmove < 800 && nextmove > 0)
                        bila.Y = nextmove;
                    else//effectul oglinda=>schimba unghiul
                    {
                        bila.Angle =-bila.Angle;
                        if (nextmove >= 800)
                            bila.Y = 800 - Math.Abs(nextmove - 800);
                        else
                            bila.Y = -nextmove;
                    }
                    nextmove = Math.Cos(bila.Angle * PI / 180) * bila.Speed + bila.X;
                    if (nextmove < 1300 && nextmove > 0)
                        bila.Y = nextmove;
                    else
                    {
                        bila.Angle =(bila.Angle<0?-180:180)-bila.Angle;
                        if (nextmove >= 1300)
                            bila.Y = 1300 - Math.Abs(nextmove - 1300);
                        else
                            bila.Y = -nextmove;
                    }
                    //s-a mutat pe urmatoarea pozitie
                    foreach (var bilaVecina in lista.ToList())
                        if (bilaVecina.Id != bila.Id && Distanta(bila.Position, bilaVecina.Position) - bila.Raza - bilaVecina.Raza < 0)//se ating 2 bile 
                        {
                            if (!bila.Touched(bilaVecina.Id))//collision occurs if last Tick the 2 balls have not collided
                                Collision(bila, bilaVecina);
                            bila.Touched(bilaVecina.Id);
                            bilaVecina.Touched(bila.Id);
                        }
                        else
                            bila.RemoveVisitor(bilaVecina.Id);//resets the collision EVENT to Enabled
                    
                }
            }
            //Update canvas
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);
            foreach(var ball in lista)
            {
                SolidBrush brush = new SolidBrush(ball.Color);
                grp.FillEllipse(brush, (float)ball.X - (float)ball.Raza, (float)ball.Y - (float)ball.Raza, 2* (float)ball.Raza, 2* (float)ball.Raza);
                using (Font myFont = new Font("Arial", 10))
                {
                    grp.DrawString(Prescurtare(ball.Type), myFont, Brushes.Black, new PointF((float)ball.X,(float)ball.Y));
                }
            }
            pictureBox1.Image = bmp;

        }

        private string Prescurtare(string type)
        {
            switch (type)
            {
                case "RegBall":
                    return "RG";
                case "RepBall":
                    return "RP";
                case "MonBall":
                    return "M";
            }
            return "";
        }

        private bool Paralel()
        {
            //TODO
            //should determine if 1 or more balls are paralel to each other
            return false;
        }

        public double Distanta(Punct p1,Punct p2)
        {
            return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        }
        private void Collision(Ball b1, Ball b2)
        {


            //caz 1
            if (b1.Type == "RegBall" && b2.Type == "RegBall")
            {
                Ball blarge, bsmall;
                if (b1.Raza < b2.Raza)
                { blarge = b2; bsmall = b1; }
                else
                { blarge = b1; bsmall = b2; }
                blarge.Raza += bsmall.Raza;
                blarge.ColorChange(bsmall.Raza / (blarge.Raza + bsmall.Raza), bsmall.Color);
                lista.Remove(bsmall);
            }
            else//caz2
                if ((b1.Type == "Regball" && b2.Type == "MonBall") || (b2.Type == "Regball" && b1.Type == "MonBall"))
            {
                Ball rball;
                Ball mball;
                if (b1.Type == "RegBall")
                { rball = b1; mball = b2; }
                else
                { rball = b2; mball = b1; }
                mball.Raza += rball.Raza;
                lista.Remove(rball);
            }
            else//caz3
                if ((b1.Type == "Regball" && b2.Type == "RepBall") || (b2.Type == "Regball" && b1.Type == "RepBall"))
            {
                Ball rball;
                Ball rpball;
                if (b1.Type == "RegBall")
                { rball = b1; rpball = b2; }
                else
                { rball = b2; rpball = b1; }
                rpball.Color = rball.Color;
                rball.Angle = rball.Angle < 0 ? rball.Raza + 180 : rball.Raza - 180;
            }
            else//caz4
                if (b1.Type + b2.Type == "RepBallRepBall")
            {
                Color colAux = b1.Color;
                b1.Color = b2.Color;
                b2.Color = colAux;
            }
            else//caz 5
            {
                if (b1.Type == "RepBall")
                    b1.Raza /= 2;
                else
                    b2.Raza /= 2;
            }
        }
    }
}
