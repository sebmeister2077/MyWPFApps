
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace BBG_BigBallGame
{
    public partial class BBG : Form
    {
        const double PI = Math.PI;
        static Random rnd = new Random();
        Timer t;
        private int regular, repelent, monster;//Counts the number of balls
        List<Ball> lista;
        Bitmap bmp;
        Graphics grp;
        Stack<Ball> remove;
        Queue<(Ball,int)> buffer;//buffer used to delay ball.RemoveVisitor(theOtherBall.id);//using Tuple
        bool randomMode = false;
        int[] ratios;
        public BBG()
        {
            InitializeComponent();
        }
        private void BBG_Load(object sender, EventArgs e)
        {
            bmp = new Bitmap(1300, 800);
            remove = new Stack<Ball>();
            lista = new List<Ball>();
            buffer = new Queue<(Ball, int)>();
            ratios = new int[3] {6,3,1 };
            regular = int.Parse(txbxReg.Text);
            repelent = int.Parse(txbxRep.Text);
            monster = int.Parse(txbxMon.Text);
            Initialize(ReturnBallCount()) ;//amount of balls as parameter
            Start();
        }

        private void Initialize(int n,bool random=false)
        {
            remove = new Stack<Ball>();
            lista = new List<Ball>();
            int auxm, auxrp, auxrg;//in caz ca este cu nr fix de bile x,y,si z
            if (random)
            {
                regular = 0;
                repelent = 0;
                monster = 0;
            } 
            auxm = monster;
            auxrp = repelent;
            auxrg = regular;
            while (n-- > 0)
            {
                Ball b = new Ball(n+1);
                b.Raza = (7 - Math.Log((rnd.Next() % 120+2) * 3))*6+10;//higher chance for smaller balls spawning
                b.Position = new Punct(rnd.Next() % 1250 + 25, rnd.Next() % 750 + 25);
                b.Color = Color.FromArgb(200,(byte)(rnd.Next() % 255), (byte)(rnd.Next() % 255), (byte)(rnd.Next() % 255));
                b.Angle = rnd.Next() % 361 - 181;//interval: [-180,180]
                b.Speed = (rnd.Next() % 5)*3 + 4;
                if (random == true)
                {
                    int aux = rnd.Next() % (ratios[0] + ratios[1] + ratios[2]);
                    if (aux < ratios[2])
                    { b.Type = "MonBall"; b.Speed = 0; monster++; b.Raza = Math.Max(6, b.Raza / 4); }// sanse: 1/10  +raza mai mica
                    else
                        if (aux < ratios[2] + ratios[1])
                    { b.Type = "RepBall"; repelent++; }//  3/10
                    else
                    { b.Type = "RegBall"; regular++; }//   6/10
                }
                else
                {
                    if (auxm-- > 0)
                    { b.Type = "MonBall"; b.Speed = 0; b.Raza = Math.Max(6, b.Raza / 4); }
                    else
                        if (auxrp-- > 0)
                        b.Type = "RepBall";
                    else
                        b.Type = "RegBall";

                }
                lista.Add(b);
            }
        }

        private int ReturnBallCount()
        {
            if (!randomMode)
            {
                return monster + repelent + regular;
            }
            else
                return ushort.Parse(txbxballs.Text);
        }

        private void Start()
        {
            t = new Timer();
            t.Interval = 160-trckbarSpeed.Value*15;
            t.Tick += T_Tick;
            t.Enabled = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if ((monster>0&&repelent==0&&regular==0)||(monster==0&&regular==1))//TODO detectare cand nu se vor mai putea efectua coliziuni datorita Unghiurilor a 1 sau mai multor bile
            { t.Stop(); MessageBox.Show("Simulare incheiata."); }
            else
            {
                foreach (var bila in lista.ToList())
                {
                    if (bila.Raza < 2)
                    { bila.Id=0;remove.Push(bila); repelent--; continue; }//numai bilele repelent se micsoreaza,restul Doar cresc,raman la fel sau dispar
                    if(bila.Id==0)
                    { remove.Push(bila);continue; }//bila eliminata(mancata),doar bilele regular sunt mancate
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
                        bila.X = nextmove;
                    else
                    {
                        bila.Angle =(bila.Angle<0?-180:180)-bila.Angle;
                        if (nextmove >= 1300)
                            bila.X = 1300 - Math.Abs(nextmove - 1300);
                        else
                            bila.X = -nextmove;
                    }
                    //s-a mutat pe urmatoarea pozitie
                    foreach (var bilaVecina in lista.ToList())
                        if (bilaVecina.Id != 0)//in caz ca in unul din pasii treciti dar in acelasi tick bila aceasta a fost deja eliminta
                            if (bilaVecina.Id != bila.Id && Distanta(bila.Position, bilaVecina.Position) - bila.Raza - bilaVecina.Raza < 0)//se ating 2 bile 
                            {
                                if (!bila.Touched(bilaVecina.Id))//collision occurs if last Tick the 2 balls have not collided
                                    Collision(bila, bilaVecina);
                                bila.Touched(bilaVecina.Id);
                                bilaVecina.Touched(bila.Id);
                            }
                            else
                                buffer.Enqueue((bila, bilaVecina.Id));
                }
            }
            //Remove deleted balls from lista and resets the collision EVENT to Enabled
            while (remove.Count > 0)
                lista.Remove(remove.Pop());
            while (buffer.Count > 0)
                buffer.Peek().Item1.RemoveVisitor(buffer.Dequeue().Item2);
            //Update canvas
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.AntiqueWhite);
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

        private void trckbarSpeed_Scroll(object sender, EventArgs e)
        {
            t.Interval = 160-trckbarSpeed.Value * 15;
        }

        private void btnreset_Click(object sender, EventArgs e)
        {
            t.Stop();
            btnPauseResume.Text = "Pause";
            btnPauseResume.ForeColor = Color.Red;
            monster = int.Parse("0"+txbxMon.Text);
            repelent = int.Parse("0"+txbxRep.Text);
            regular = int.Parse("0"+txbxReg.Text);
            Initialize(ReturnBallCount(),randomMode);
            Start();
        }
        private double Distanta(Punct p1,Punct p2)
        {
            return Math.Sqrt((p2.X - p1.X) * (p2.X - p1.X) + (p2.Y - p1.Y) * (p2.Y - p1.Y));
        }
        private void Collision(Ball b1, Ball b2)
        {
            //caz 1
            //delete
            if (b1.Type == "RegBall" && b2.Type == "RegBall")
            {
                Ball blarge, bsmall;
                if (b1.Raza < b2.Raza)
                { blarge = b2; bsmall = b1; }
                else
                { blarge = b1; bsmall = b2; }
                blarge.Raza += bsmall.Raza;
                blarge.ColorChange(bsmall.Raza / (blarge.Raza + bsmall.Raza), bsmall.Color);
                bsmall.Id = 0;
                remove.Push(bsmall);
                regular--;
            }
            else//caz2
            //delete
                if ((b1.Type == "RegBall" && b2.Type == "MonBall") || (b2.Type == "RegBall" && b1.Type == "MonBall"))
            {
                Ball rball;
                Ball mball;
                if (b1.Type == "RegBall")
                { rball = b1; mball = b2; }
                else
                { rball = b2; mball = b1; }
                mball.Raza += rball.Raza;
                rball.Id = 0;
                remove.Push(rball);
                regular--;
            }
            else//caz3
                if ((b1.Type == "RegBall" && b2.Type == "RepBall") || (b2.Type == "RegBall" && b1.Type == "RepBall"))
            {
                Ball rball;
                Ball rpball;
                if (b1.Type == "RegBall")
                { rball = b1; rpball = b2; }
                else
                { rball = b2; rpball = b1; }
                rpball.Color = rball.Color;
                if(ChckboxCollide.Checked==false)
                rball.Angle += rball.Angle < 0 ? 180 : - 180;
                else
                {
                    rball.Angle = MergeAngles(rball.Angle,CreateAngle(rpball.Position,rball.Position));
                    rpball.Angle = MergeAngles(rpball.Angle, CreateAngle(rball.Position,rpball.Position));
                }    
            }
            else//caz4
                if (b1.Type + b2.Type == "RepBallRepBall")
            {
                Color colAux = b1.Color;
                b1.Color = b2.Color;
                b2.Color = colAux;
                if(ChckboxCollide.Checked==true)
                {
                    b1.Angle = MergeAngles(b1.Angle, CreateAngle(b2.Position, b1.Position));
                    b2.Angle = MergeAngles(b2.Angle, CreateAngle(b1.Position, b2.Position));
                }
            }
            else//caz 5
            if((b1.Type == "RepBall" && b2.Type == "MonBall") || (b2.Type == "RepBall" && b1.Type == "MonBall"))
            {
                Ball rpball;
                Ball monball;
                if (b1.Type == "RepBall")
                { rpball = b1; monball = b2; }
                else
                { rpball = b2; monball = b1; }
                rpball.Raza /= 2;
                rpball.Angle = MergeAngles(rpball.Angle, CreateAngle(monball.Position, rpball.Position));
            }
        }
        double RadiansToDegrees(double valRad)
        {
            return (360 / (2 * Math.PI) * valRad);
        }
        double DegreesToRadians(double valDeg)
        {
            return ((2 * Math.PI) / 360 * valDeg);
        }
        ///<summary>
        ///Creates an Angle(from -180,to 180)
        ///0 Indicating right, 180 or -180 indicating left, 90 up and -90 down
        /// </summary>
        private double CreateAngle(Punct basePosition, Punct relativePosition)
        {
            double catetaX,catetaY;
            catetaX = Math.Abs(basePosition.X - relativePosition.X);
            catetaY = Math.Abs(basePosition.Y - relativePosition.Y);
            double unghi=0;
            if (catetaX > 0 && catetaY > 0)
                unghi = RadiansToDegrees(Math.Atan(catetaY / catetaX));
            else
            {
                if (catetaX == 0)
                    return basePosition.Y > relativePosition.Y ? -90 : 90;
                else
                    return basePosition.X > relativePosition.X ? 0 : 180;
            }
            //cele 4 cadrane=>4cazuri
            if (relativePosition.Y > basePosition.Y)
            {
                if (relativePosition.X > basePosition.X)//dreapta jos
                    unghi = -unghi;
                else
                    unghi = -180 + unghi;//stanga jos
            }
            else
                if (relativePosition.X < basePosition.X)
                unghi = 180 - unghi;
            return unghi;
        }
        /// <summary>
        /// Combines 2 Angles ∈ [-180,180]
        /// (Used for Vectors)
        /// </summary>
        private double MergeAngles(double angle1,double angle2)
        {
            double min= Math.Min(angle1, angle2), max= Math.Max(angle1, angle2);
            if(Math.Abs(angle1-angle2)<=180)
            return max- Math.Abs(angle1 - angle2)/2;
            if (Math.Abs(min) > Math.Abs(max))
                return max + (180 + min + 180 - max) / 2;//max+jumatatea diferentei
            else
                return min + (-180-min-180-max)/2;
            

        }
        #region Mode Select
        private void rbtnCountMode_CheckedChanged(object sender, EventArgs e)
        {
            if (randomMode==false &&rbtnCountMode.Checked == false)
                rbtnCountMode.Checked = true;//cant uncheck mode,you can only switch mode by checking the other radio btn mode
            else
            if(randomMode==true&&rbtnCountMode.Checked==true)
            {//switch
                randomMode = false;
                rbtnGenMode.Checked = false;
                txbxballs.Enabled = false;
                txtratioMon.Enabled = false;
                txtratioRep.Enabled = false;
                txtratioReg.Enabled = false;
                txbxMon.Enabled = true;
                txbxRep.Enabled = true;
                txbxReg.Enabled = true;
            }
        }
        private void rbtnGenMode_CheckedChanged(object sender, EventArgs e)
        {
            if (randomMode==true&& rbtnGenMode.Checked == false)
                rbtnGenMode.Checked = true;//cant uncheck mode,you can only switch mode by checking the other radio btn mode
            else
            if(randomMode==false&&rbtnGenMode.Checked==true)
            {//switch
                randomMode = true;
                rbtnCountMode.Checked = false;
                txbxballs.Enabled = true;
                txbxMon.Enabled = false;
                txbxRep.Enabled = false;
                txbxReg.Enabled = false;
                txtratioMon.Enabled = true;
                txtratioRep.Enabled = true;
                txtratioReg.Enabled = true;
            }
        }
        #endregion
        #region TextBoxes on the spot verification
        //automatically verifies in place(while user is inputting) if if is a valid number and replaces it if necessary

        private void txbxballs_TextChanged(object sender, EventArgs e)
        {
            if(txbxballs.Text!="")
            txbxballs.Text = Min(50, Max(1, int.Parse(txbxballs.Text))).ToString();
        }
        private void txtratioReg_TextChanged(object sender, EventArgs e)
        {
            if (txtratioReg.Text != "")
            {
                txtratioReg.Text = Min(100, Max(0, int.Parse(txtratioReg.Text))).ToString();
                ratios[0] = int.Parse(txtratioReg.Text);
            }
            else ratios[0] = 0;
        }
        private void txtratioRep_TextChanged(object sender, EventArgs e)
        {
            if (txtratioRep.Text != "")
            {
                txtratioRep.Text = Min(100, Max(0, int.Parse(txtratioRep.Text))).ToString();
                ratios[1] = int.Parse(txtratioRep.Text);
            }
            else ratios[1] = 0;
        }
        private void txtratioMon_TextChanged(object sender, EventArgs e)
        {
            if (txtratioMon.Text != "")
            {
                txtratioMon.Text = Min(100, Max(0, int.Parse(txtratioMon.Text))).ToString();
                ratios[2] = int.Parse(txtratioMon.Text);
            }
            else ratios[2] = 0;
        }
        private void txbxReg_TextChanged(object sender, EventArgs e)
        {
            if (txbxReg.Text != "")
            {
                txbxReg.Text = Min(30, Max(0, int.Parse(txbxReg.Text))).ToString();
                regular = int.Parse(txbxReg.Text);
            }
            else regular = 0;
        }

        private void txbxRep_TextChanged(object sender, EventArgs e)
        {
            if (txbxRep.Text != "")
            {
                txbxRep.Text = Min(30, Max(0, int.Parse(txbxRep.Text))).ToString();
                repelent = int.Parse(txbxRep.Text);
            }
            else repelent = 0;
        }

        private void txbxMon_TextChanged(object sender, EventArgs e)
        {
            if (txbxMon.Text != "")
            {
                txbxMon.Text = Min(10, Max(0, int.Parse(txbxMon.Text))).ToString();
                monster = int.Parse(txbxMon.Text);
            }
            else monster = 0;
        }

        #endregion
        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if(btnPauseResume.Text=="Pause")
            {
                btnPauseResume.Text = "Resume";
                btnPauseResume.ForeColor = Color.Green;
                t.Stop();
            }
            else
            {
                t.Start();
                btnPauseResume.Text = "Pause";
                btnPauseResume.ForeColor = Color.Red;
            }
        }

        private void ChckboxCollide_MouseHover(object sender, EventArgs e)
        {
            System.Windows.Forms.ToolTip ttip = new System.Windows.Forms.ToolTip();
            this.Controls.Add(ChckboxCollide);
            ttip.Active = true;
            ttip.SetToolTip(ChckboxCollide, "Simulates better collision between 2 balls without taking into account of their type");
        }

        public int Min(int a,int b)
        {
            return Math.Min(a, b);
        }
        public int Max(int a,int b)
        { return Math.Max(a, b); }
    }
}
