using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG_BigBallGame
{
    class Trail
    {
        float x, y;
        int width, height;
        int stAngle, swpAngle;
        Color color;
        public Trail() { }
        /// <summary>
        /// Creates a Trail based on an Arc and a Color
        /// </summary>
        public Trail(float x,float y,int width,int height, int startAngle,int sweepAngele,Color c)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            this.stAngle = startAngle;
            this.swpAngle = sweepAngele;
            this.color = c;
        }
        /// <summary>
        /// Creates a Trail based on an Arc and a Color
        /// </summary>
        public Trail(Punct p, int width, int height, int startAngle, int sweepAngele, Color c) 
            : this((float)p.X, (float)p.Y, width, height, startAngle, sweepAngele, c) { }
        /// <summary>
        /// Creates a Trail based on another Trail
        /// </summary>
        public Trail(Trail t):this(t.x,t.y,t.width,t.height,t.stAngle,t.swpAngle,t.color)
        { }
        public void Draw(Graphics grp)
        {
            grp.DrawArc(new Pen(color), x, y, width, height, stAngle, swpAngle);
        }
    }
}
