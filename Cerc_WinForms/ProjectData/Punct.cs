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
    }
}
