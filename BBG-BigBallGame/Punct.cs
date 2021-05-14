using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG_BigBallGame
{
    public class Punct
    {
        double x, y;
        public Punct() { }
        public Punct(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public Punct(Punct p)
        {
            this.x = p.x;
            this.y = p.y;
        }
        public double X
        {
            get { return x; }
            set { x = value; }
        }
        public double Y
        {
            get { return y; }
            set { y = value; }
        }
        public static Punct operator +(Punct p1, Punct p2) => new Punct(p1.X + p2.X, p1.Y + p2.Y);
    }
}
