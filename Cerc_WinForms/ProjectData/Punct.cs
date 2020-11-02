using System;
using System.Drawing;

namespace ProjectData
{
    
    public class Punct
    {
        private float mutaPeCerc;
        private float mutaPeRaza;
        public float x, y;
        public Punct()
        {

        }
        public Punct(int i, int n,float _mutaPeCerc,float _mutaPeRaza)
        {
            mutaPeCerc = _mutaPeCerc;
            mutaPeRaza = _mutaPeRaza;
            if (i % 2 == 0)
            {
                x = 700 / 2 + 340 * (float)Math.Cos((float)360 / n * i * Math.PI / 180);
                y = 700 / 2 - 340 * (float)Math.Sin((float)360 / n * i * Math.PI / 180);
            }
            else
            {
                x = 700 / 2 + (340 - mutaPeRaza) * (float)Math.Cos((float)360 / n * i * Math.PI / 180 + mutaPeCerc);
                y = 700 / 2 - (340 - mutaPeRaza) * (float)Math.Sin((float)360 / n * i * Math.PI / 180 + mutaPeCerc);
            }
        }
        private static int CatDeDeparte(int i,int layers)
        {
            //cat de departe e un anumit punt de unul dintre cele mai aporape 2 puncte divizibile cu layers+1
            int depstg = 0, depdr = 0;
            depstg = i % (layers + 1);
            depdr = (int)Math.Abs((i - i / (layers + 1) + depstg));
            return Math.Min(depstg, depdr);
        }
        public Punct(int i, int n,float _mutaPeCerc, int layers,int distance)
        {
            mutaPeCerc = _mutaPeCerc;
            x = 700 / 2 + (340 - (7 * CatDeDeparte(i,layers)* distance)) * (float)Math.Cos((float)360 / n * i * Math.PI / 180 + mutaPeCerc*CatDeDeparte(i,layers));
            y = 700 / 2 - (340 - (7 * CatDeDeparte(i,layers)* distance)) * (float)Math.Sin((float)360 / n * i * Math.PI / 180 + mutaPeCerc*CatDeDeparte(i,layers));
        }
    }
}
