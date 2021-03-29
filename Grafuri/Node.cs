using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grafuri
{
    class Node
    {
        float x, y;
        int id;
        public Node() { }
        public Node(float x, float y)
        {
            this.x = x;
            this.y = y;
        }
        public Node(Node n)
        {
            this.x = n.x;
            this.y = n.y;
        }
        #region Properties
        public float X
        {
            get { return x; }
        }
        public float Y
        {
            get { return y; }
        }
        public int Id
        {
            
            get { return id; } 
            set { id = value; }
        }
        public PointF Position
        {
            get { return new PointF(x, y); }
            set { this.x = value.X;this.y = value.Y; }
        }
        #endregion
    }
}
