using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Imaging;

namespace Photo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Bitmap bmp,current,sursa;
        private void Form1_Load(object sender, EventArgs e)
        {
            sursa = new Bitmap(@"..\...\Photos\butterfly.jpg");
            bmp = new Bitmap(sursa.Width, sursa.Height);
            current = new Bitmap(sursa.Width, sursa.Height);
            for(int i=0;i<sursa.Width;i++)
                for(int j=0;j<sursa.Height;j++)
                {
                    bmp.SetPixel(i,j,sursa.GetPixel())
                }
        }
    }
}
