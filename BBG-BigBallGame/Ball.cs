using System.Collections.Generic;
using System.Drawing;

namespace BBG_BigBallGame
{
    public class Ball
    {
        int id;
        HashSet<int> visitorlist=new HashSet<int>();//colletion used to make only 1 collision Effect per collision Encounter(o singura atingere/coliziune),and not per collosion Time(slow speed/big radius==more time)
        double raza;
        Punct poz;
        Color col;
        double dirsens;//va fi un unghi cuprins intre 180 si -180* ,0* fiind directia stanga,90* directia jos(pt ca pt canvas sus ar fi jos)
        double viteza;//interval: [1,5]
        string type="";

        #region Constructor
        public Ball()
        { }
        public Ball(int id)
        { this.id = id; }
        public Ball(double r, Punct p, Color c, double dirsens, double viteza)
        {
            this.raza = r;
            this.poz = p;
            this.col = c;
            this.dirsens = dirsens;
            this.viteza = viteza;
        }
        public Ball(double r, Punct p, Color c, double dirsens, double viteza, string type) : this(r, p, c, dirsens, viteza)
        { this.type = type; }
        public Ball(Ball b):this(b.raza,b.poz,b.col,b.dirsens,b.viteza)
        {
            this.id = b.id;
            if (b.type != "")
                this.type = b.type;
        }
        #endregion
        #region Properties
        public double Raza
        {
            get
            { return raza;}
            set
            {  raza = value;}
        }
        public Punct Position
        {
            get { return poz; }
            set { poz = value; }
        }
        public Color Color
        {
            get { return col; }
            set { col = value; }
        }
        public double Angle
        {
            get { return dirsens; }
            set { dirsens = value; }
        }
        public double Speed
        {
            get { return viteza; }
            set { viteza = value; }

        }
        public string Type
        {
            get { return type; }
            set { type = value; }

        }
        public double X
        {
            get { return poz.X; }
            set { poz.X = value; }
        }
        public double Y
        {
            get { return poz.Y; }
            set { poz.Y = value; }
        }
        public int Id
        {
            get { return id; }
        }
        #endregion
        #region Methods
        public bool Touched(int id)
        {
            return visitorlist.Contains(id);
        }
        public void RemoveVisitor(int id)
        {
            visitorlist.Remove(id);//removes a past collision with ball.Id from history(collection)
        }
        public void ColorChange(double ratio,Color c)
        {
            this.col = Color.FromArgb(200, (byte)(col.R*(1 - ratio)+(c.R*ratio)), (byte)(col.G * (1 - ratio) + (c.G * ratio)), (byte)(col.B * (1 - ratio) + (c.B * ratio)));
        }
        #endregion
    }
}
