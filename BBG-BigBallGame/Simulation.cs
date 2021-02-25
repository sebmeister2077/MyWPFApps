
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
            MessageBox.Show(Math.Sin(30*Math.PI/180).ToString());
            
            //Initialize(15);//amount of balls as parameter
           // Start();
        }

        private void Initialize(int n)
        {
            regular = 0;
            repelent = 0;
            monster = 0;
            while (n-- > 0)
            {
                Ball b = new Ball(n+1);
                b.Raza = (5 - Math.Log((rnd.Next() % 20) * 3)) * 8+2;//higher chance for smaller balls spawning
                b.Position = new Punct(rnd.Next() % 1250 + 25, rnd.Next() % 750 + 25);
                b.Color = Color.FromArgb(200,(byte)(rnd.Next() % 255), (byte)(rnd.Next() % 255), (byte)(rnd.Next() % 255));
                b.Angle = rnd.Next() % 360 - 180;//interval: [-180,180)
                b.Speed = rnd.Next() % 9 + 1;
                int aux = rnd.Next() % 9;
                if (aux == 0)
                    b.Type = "MonsterBall";// sanse: 1/9
                else
                    if (aux < 4)
                { b.Type = "RepelentBall"; repelent++; }//  3/9
                else
                { b.Type = "RegularBall"; regular++; }//   5/9
                lista.Add(b);
            }
        }
        private void Start()
        {
            t = new Timer();
            t.Interval = 70;
            t.Tick += T_Tick;
            t.Enabled = true;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            if (monster == 0 && regular <= 1)
            { t.Stop(); MessageBox.Show("Simulare incheiata."); }
            else
            {
                foreach (var bila in lista)
                {
                    if (bila.Raza < 3)
                    { lista.Remove(bila); continue; }
                    double nextmove = Math.Sin(bila.Angle * PI / 180) * bila.Speed + bila.Y;
                    if (nextmove >= 800||nextmove<0)

                }
            }
        }
    }
}
