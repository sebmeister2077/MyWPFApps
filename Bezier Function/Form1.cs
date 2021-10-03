using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier_Function
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static Size formSize = new Size(1025, 600);
        static bool drawExtras = false;
        static bool dontClear = false;
        static bool crazyMode = false;
        static Point mouseBefore;

        static Timer timer;
        static Graphics grps;
        static Bitmap bmp;

        static bool gameState = false;
        static int numberOfPoints = 0;
        static List<Point> points;
        static int percent = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            points = new List<Point>();
            timer = new Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            timer.Stop();
            bmp = new Bitmap(canvas.Width, canvas.Height);
            grps = Graphics.FromImage(bmp);
            mouseBefore = new Point(0, 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            percent = (percent + 1) % 100;
            if(points.Count > 0)
                RenderImage();
        }

        private void RenderImage()
        {
            if(!dontClear)
                grps.Clear(canvas.BackColor);
            SolidBrush brush = new SolidBrush(Color.FromArgb(65, 119, 153));

            DrawPointsAndLines(points.ToArray(), brush, Pens.Black);

            Point bezierPoint = BezierFunction(points.ToArray(), (double)percent / 100);
            grps.FillEllipse(Brushes.Blue, bezierPoint.X - 5, bezierPoint.Y - 5, 10, 10);
            canvas.Image = bmp;
        }

        private void DrawPointsAndLines(Point[] givenPoints,Brush brush,Pen pen)
        {
            foreach (Point point in givenPoints)
                grps.FillEllipse(brush, point.X - 5, point.Y - 5, 10, 10);
            for (int i = 0; i < givenPoints.Length - 1; i++)
                grps.DrawLine(Pens.Black, points[i], points[i + 1]);
        }

        private void ResetVars()
        {
            HandleGameStateChange(false);
            timer.Stop();
            points = new List<Point>();
            percent = 0;
            grps.Clear(canvas.BackColor);
        }

        private void HandleGameStateChange(bool? value = null)
        {
            if (value != null)
                gameState = (bool)!value;
            button1.Text = gameState ? "Start" : "Stop";
            button1.ForeColor = gameState ? Color.LawnGreen: Color.Red;
            gameState = !gameState;
            if (gameState)
                timer.Start();
            else
                timer.Stop();
        }

        private Point BezierFunction(Point[] givenPoints,double percentage,int level=1)
        {
            if (givenPoints.Length == 1)
                return givenPoints[0];
            if (givenPoints.Length == 2)
                return BezierPoint(givenPoints[0], givenPoints[1], percentage);

            Point[] bezierPoints = new Point[givenPoints.Length-1];
            for (int i = 0; i < givenPoints.Length - 1; i++)
                bezierPoints[i] = BezierPoint(givenPoints[i], givenPoints[i + 1], percentage);

            SolidBrush brush = new SolidBrush(Color.FromArgb((int)(255 - 250 * ((double)level / points.Count)), 159, 159, 159));
            if(drawExtras)
            DrawPointsAndLines(bezierPoints,brush, Pens.White);

            return BezierFunction(bezierPoints, percentage, level + 1);
        }

        private Point BezierPoint(Point pointA,Point pointB,double percentage) => 
            new Point((int)((1 - percentage) * pointA.X + percentage * pointB.X), (int)((1 - percentage) * pointA.Y + percentage * pointB.Y));

        private void button1_Click(object sender, EventArgs e)
        {
            HandleGameStateChange();
        }

        private void txtbxPoints_TextChanged(object sender, EventArgs e)
        {
            ResetVars();

            string text = txtbxPoints.Text;
            string[] lines = text.Split('\n');
            Regex reg = new Regex(@"\([0-9]+,[0-9]+\)");
            MatchCollection matches = reg.Matches(text);

            txtbxNumber.Text = matches.Count.ToString();
            numberOfPoints = matches.Count;
            foreach (string line in lines)
                if (reg.Match(line).Success)
                    points.Add(line.StringToPoint());
        }

        private void txtbxNumber_TextChanged(object sender, EventArgs e)
        {
            ResetVars();

            string text = txtbxNumber.Text;
            Regex reg = new Regex(@"\D");
            MatchCollection matches = reg.Matches(text);
            if (matches.Count == 0&& text.Length > 0)
                numberOfPoints = int.Parse(text);
        }

        private void canvas_Click(object sender, EventArgs e)
        {
            grps.Clear(canvas.BackColor);
            if (!gameState)
                return;
            if (points.Count < numberOfPoints)
            {
                MouseEventArgs mouseE = (MouseEventArgs)e;
                points.Add(mouseE.Location);
            }
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("chrome.exe", "https://www.youtube.com/watch?v=pnYccz1Ha34");
        }

        private void chkbxVisibility_CheckedChanged(object sender, EventArgs e) => drawExtras = chkbxVisibility.Checked;

        private void chckStopClear_CheckedChanged(object sender, EventArgs e) => dontClear = !dontClear;

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void dragPanel_MouseDown(object sender, MouseEventArgs e) => mouseBefore = new Point(e.X, e.Y);

        private void dragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if (crazyMode)
                    Location = new Point(Location.X + mouseBefore.X - e.X, Location.Y + mouseBefore.Y - e.Y);
                else
                    Location = new Point(Location.X - mouseBefore.X + e.X, Location.Y - mouseBefore.Y + e.Y);
                mouseBefore = new Point(e.X, e.Y);
            }
        }
    }
    public static class StringExtensionCLass
    {
        public static Point StringToPoint(this string str)
        {
            string[] coords = str.Trim().Split(',');
            return new Point(int.Parse(coords[0].Substring(1)), int.Parse(coords[1].Substring(0, coords[1].Length - 1)));
        }
    }
}
