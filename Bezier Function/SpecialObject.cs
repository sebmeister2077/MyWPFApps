using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bezier_Function
{
    public class SpecialObject
    {
        public SpecialObject() { }

        public SpecialObject(Bitmap bitmap,string points,int count)
        {
            Image = new Bitmap(bitmap);
            Points = points;
            Count = count;
        }
        public SpecialObject(Bitmap bitmap, string points,int count,string title,bool isRandom=false)
        {
            Image = new Bitmap(bitmap);
            Points = points;
            Count = count;
            Title = title;
            IsRandom = IsRandom;
        }

        public SpecialObject(SpecialObject specialObj) : this(specialObj.Image, specialObj.Points,specialObj.Count) { Title = specialObj.Title; }

        public Bitmap Image { get; set; }

        public string Points { get; set; }

        public int Count { get; set; }

        public string Title { get; set; }

        public bool IsRandom { get; set; }
    }
}
