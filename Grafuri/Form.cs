using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafuri
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            lista = new List<Node>();
            connections = new HashSet<Connection>();
            nodes = 0;
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            grp = Graphics.FromImage(bmp);
        }
        Bitmap bmp;
        Graphics grp;
        List<Node> lista;
        HashSet<Connection> connections;
        int nodes;
        bool isDragging = false;
        int index;
        private void btnAddNode_Click(object sender, EventArgs e)
        {
            btnAddNode.Enabled = false;
            btnconn.Enabled = false;
            nodes++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (nodes > lista.Count)
            {
                Node n = new Node();
                MouseEventArgs me = (MouseEventArgs)e;
                n.Position = me.Location;
                n.Id = nodes - 1;
                lista.Add(n);
                RefreshDrawing();
                btnAddNode.Enabled = true;
                btnconn.Enabled = true;
            }
            else
                if (!isDragging)
            {
                index = 0;
                foreach (var item in lista)
                    if (AreClose(((MouseEventArgs)e).Location, item.Position, 15))
                    {
                        index = item.Id;
                        isDragging = true;
                        break;
                    }
            }
            else
                isDragging = false;
        }
        private void btnconn_Click(object sender, EventArgs e)
        {
            ushort i, j;
            if (ErrorParsing(out i,out j))
                lblError.Visible = true;
            else
            {
                lblError.Visible = false;
                
                if (connections.Contains(new Connection(i, j)))
                    lblExists.Visible = true;
                else
                {
                    lblExists.Visible = false;
                    connections.Add(new Connection(i, j));
                    grp.DrawLine(Pens.Black, lista.ElementAt(i).Position, lista.ElementAt(j).Position);
                    pictureBox1.Image = bmp;
                }
            }
        }
        private bool ErrorParsing(out ushort i,out ushort j)
        {
            i = 0;j = 0;
            if (!ushort.TryParse(txbxconn1.Text, out i))
                return true;
            if (!ushort.TryParse(txbxconn2.Text, out j))
                return true;
            i = ushort.Parse(txbxconn1.Text);
            j = ushort.Parse(txbxconn2.Text);
            if (i >= lista.Count || j >= lista.Count)
                return true;
            return false;
        }
        private void RefreshDrawing()
        {
            grp.Clear(Color.White);
            foreach (Node n in lista)
            {
                grp.DrawEllipse(Pens.Silver, new RectangleF(new PointF(n.X - 20, n.Y - 20), new SizeF(40, 40)));
                using (Font myFont = new Font("Arial", 7))
                {
                    grp.DrawString(n.Id.ToString(), myFont, Brushes.Black,n.Position);
                }
            }
            foreach (Connection con in connections)
                grp.DrawLine(Pens.Gray, lista.ElementAt(con.I).Position, lista.ElementAt(con.J).Position);
            pictureBox1.Image = bmp;
        }

        private bool AreClose(Point p1, PointF p2, int v)
        {
            //returns true if 2 points are whithin a certain distance of each other
            return v > Math.Sqrt((p1.X-p2.X)* (p1.X - p2.X)+ (p1.Y - p2.Y)* (p1.Y - p2.Y));
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            isDragging = false;
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            if (nodes > 0&&isDragging)
            {
                MouseEventArgs me = (MouseEventArgs)e;
                lista.ElementAt(index).Position = me.Location;
                RefreshDrawing();
            }
        }
    }
}
