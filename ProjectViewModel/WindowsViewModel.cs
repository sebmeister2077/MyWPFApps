using System;
using System.Drawing;
using ProjectData;

namespace ProjectViewModel
{
    public class WindowsViewModel
    {
        private static Graphics grp;
        private static Bitmap bmp;
        private static Pen myPen = Pens.Black;
        private static int width, height;
        private static float MutaPeCerc = 0, MutaPeRaza = 0;

        public static void SetLengths(int w,int h)
        {
            width = w;
            height = h;
        }
        public static void ChangeColor(Pen newPen)
        {
            myPen = newPen;
        }
        public static void IncrementMuta(float incr1,float incr2=0f)
        {
            MutaPeCerc += incr1;
            if (MutaPeCerc >= 10000)
                MutaPeCerc = 0;
            MutaPeRaza += incr2;
            if (MutaPeRaza >= (width + height) / 1.8)
                MutaPeRaza = 0;
        }
        public static void ResetMuta(bool b1=false,bool b2=false)
        {
            if (b1 == true)
                MutaPeCerc = 0;
            if (b2 == true)
                MutaPeRaza = 0;
        }
        public static Bitmap Deseneaza(int n, int linii)
        {
            bmp = new Bitmap(width, height);
            grp = Graphics.FromImage(bmp);
            grp.Clear(Color.White);

            Punct[] v = new Punct[n];
            for (int i = 0; i < n; i++)
                v[i] = new Punct(i, n,MutaPeCerc,MutaPeRaza);
            for (int i = 0; i < n; i++)
                grp.DrawEllipse(Pens.Blue, v[i].x, v[i].y, 2, 2);

            int decateori = linii, aux = 0;
            for (int i = 0; i < n; i++)
            {
                if (i < n - decateori)
                {
                    for (int j = 1; j <= decateori; j++)
                        grp.DrawLine(myPen, v[i].x, v[i].y, v[i + j].x, v[i + j].y);
                }
                else
                {
                    aux++;
                    for (int j = 1; j <= decateori - aux; j++)
                        grp.DrawLine(myPen, v[i].x, v[i].y, v[i + j].x, v[i + j].y);
                    for (int j = 1; j <= aux; j++)
                        grp.DrawLine(myPen, v[i].x, v[i].y, v[j - 1].x, v[j - 1].y);
                }
            }
            return bmp;
        }
    }
}
