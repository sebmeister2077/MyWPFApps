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
        }
        Bitmap bmp;
        Graphics grp;
        List<Node> lista;
        HashSet<Connection> connections;
        int nodes;
        private void btnAddNode_Click(object sender, EventArgs e)
        {
            btnAddNode.Enabled = false;
            nodes++;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if(nodes>lista.Count)
            {
                Node n = new Node();
                n.Position = Cursor.Position;
                lista.Add(n);
                btnAddNode.Enabled = true;
            }
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
            if (i > lista.Count || j > lista.Count)
                return true;
            return false;
        }
        private void RefreshDrawing()
        {
            grp.Clear(Color.White);
        }
    }
}
