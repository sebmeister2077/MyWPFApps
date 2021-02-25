using System.Collections.Generic;
using System.Drawing;

namespace BBG_BigBallGame
{
    public class Ball
    {
        int id;
        List<int> visitorlist=new List<int>();//colletion used to make only 1 collision Effect per collision Encounter(o singura atingere/coliziune),and not per collosion Time(slow speed/big radius==more time)
        double raza;
        Punct poz;
        Color col;
        double dirsens;//va fi un unghi cuprins intre 180 si -180* ,0* fiind directia stanga,90* directia jos(pt ca pt canvas sus ar fi jos)
        double viteza;//interval: [1,5]
        string type;

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
        public Ball(double r, Punct p, Color c, double _dirsens, double _viteza, string _type) : this(r, p, c, _dirsens, _viteza)
        { this.type = _type; }
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
        public bool NotTouched()
        {
            return visitorlist.Count==0;//returneaza false daca a fosst in contact recent cu o anumita bila
        }
        public bool Touched(int id)
        {
            return visitorlist.Contains(id);
        }
        public void RemoveVisitor(int id)
        {
            visitorlist.Remove(id);//removes a ball from collection
        }
        #endregion
    }
}
