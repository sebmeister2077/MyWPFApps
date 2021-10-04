using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Shapes;

namespace Bezier_Function
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private const int WM_APPCOMMAND = 0x319;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        System.Media.SoundPlayer player;

        static Size formSize = new Size(1025, 600);
        static bool drawExtras = false;
        static bool dontClear = false;
        static bool crazyMode = false;
        static Point mouseBefore;
        static bool pointMoved = false;
        static Random rnd = new Random();

        static Timer timer;
        static Graphics grps;
        static Bitmap bmp;
        static bool gameState = false;
        static int numberOfPoints = 0;
        static List<Point> points;
        static int percent = 0;
        static int maxPercentage = 100;
        static bool alreadyReset = false;

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

            player = new System.Media.SoundPlayer();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            percent = (percent + 1) % maxPercentage;
            if(points.Count > 0)
                RenderImage();
        }

        #region RequiredFunctions
        private void RenderImage()
        {
            if(!dontClear)
                grps.Clear(canvas.BackColor);
            int size = ReturnRange(16 / ((double)maxPercentage / 100), 2, 10);
            SolidBrush brush = new SolidBrush(Color.FromArgb(65, 119, 153));

            DrawPointsAndLines(points.ToArray(), brush, Pens.Black);

            Point bezierPoint = BezierFunction(points.ToArray(), (double)percent / maxPercentage);
            grps.FillEllipse(Brushes.Blue, bezierPoint.X - size/2, bezierPoint.Y - size/2, size, size);
            canvas.Image = bmp;
        }

        private void DrawPointsAndLines(Point[] givenPoints,Brush brush,Pen pen)
        {
            int size = ReturnRange(12/((double)maxPercentage / 100), 2, 10);
            foreach (Point point in givenPoints)
                grps.FillEllipse(brush, point.X - size / 2, point.Y - size / 2, size, size);
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

        private int ReturnRange(double number, double min, double max) => (int)Math.Max(Math.Min(number, max), min);

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

            double difference = (double)level / points.Count;
            SolidBrush brush = new SolidBrush(Color.FromArgb((int)(255 - 256 * difference), 159, 159, 159 + (int)(difference * 90)));
            if(drawExtras)
            DrawPointsAndLines(bezierPoints,brush, Pens.White);

            return BezierFunction(bezierPoints, percentage, level + 1);
        }

        private Point BezierPoint(Point pointA,Point pointB,double percentage) => 
            new Point((int)((1 - percentage) * pointA.X + percentage * pointB.X), (int)((1 - percentage) * pointA.Y + percentage * pointB.Y));

        private double Distance(Point p1, Point p2) => Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        
        private bool IsOutsideOfCanvas(Point p) => p.X < 1 || p.Y < 1 || p.X > canvas.Width || p.Y > canvas.Height;

        #endregion

        #region RequiredEvents
        private void button1_Click(object sender, EventArgs e)
        {
            HandleGameStateChange();
        }

        private void txtbxPoints_TextChanged(object sender, EventArgs e)
        {
            string text = txtbxPoints.Text;
            string[] lines = text.Split('\n');
            Regex reg = new Regex(@"\([0-9]+,[0-9]+\)");
            MatchCollection matches = reg.Matches(text);


            bool resetVars = !pointMoved && matches.Count != numberOfPoints;
            if (resetVars)
                ResetVars();

            

            alreadyReset = true;
            txtbxNumber.Text = matches.Count.ToString();
            numberOfPoints = matches.Count;
            if (resetVars)
            foreach (string line in lines)
                if (reg.Match(line).Success)
                    points.Add(line.StringToPoint());
            pointMoved = false;
        }

        private void txtbxNumber_TextChanged(object sender, EventArgs e)
        {
            if (alreadyReset)
            {
                alreadyReset = false;
                return;
            }
            ResetVars();

            string text = txtbxNumber.Text;
            Regex reg = new Regex(@"\D");
            MatchCollection matches = reg.Matches(text);
            if (matches.Count == 0&& text.Length > 0)
                numberOfPoints = int.Parse(text);
            if (text != "")
                txtbxNumber.Text = numberOfPoints.ToString();

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
        #endregion

        #region ExtraFunctions

        private void WritePointsInText()
        {
            StringBuilder bobTheBuilder = new StringBuilder();
            foreach (Point p in points)
                bobTheBuilder.AppendLine("(" + p.X.ToString() + "," + p.Y.ToString() + ")");
            txtbxPoints.Text = bobTheBuilder.ToString();
        }

        float triangleArea(Point p1, Point p2, Point p3) => Math.Abs(((float)p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2);

        bool IsInsideTriangle(Point p1, Point p2, Point p3, Point p)
        {   
            float area = triangleArea(p1, p2, p3);         
            float area1 = triangleArea(p, p2, p3);
            float area2 = triangleArea(p1, p, p3);      
            float area3 = triangleArea(p1, p2, p);      

            return (area == area1 + area2 + area3);        
        }

        private double CalculateAlpha(Point p,Point staticPoint)
        {
            if (p.X > staticPoint.X && p.Y >= staticPoint.Y)
                return Math.Atan(p.X / p.Y);
            if (p.X > staticPoint.X && p.Y < staticPoint.Y)
                return Math.Atan(p.X / p.Y) + 2 * Math.PI;
            if (p.X < staticPoint.X)
                return Math.Atan(p.X / p.Y) + Math.PI;
            if (p.X == staticPoint.X && p.Y > staticPoint.Y)
                return Math.PI / 2;
            if (p.X > staticPoint.X && p.Y < staticPoint.Y)
                return 3 / 2 * Math.PI;
            return 0;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);
        #endregion

        #region ExtraEvents
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("chrome.exe", "https://www.youtube.com/watch?v=pnYccz1Ha34");
        }

        private void chkbxVisibility_CheckedChanged(object sender, EventArgs e) => drawExtras = chkbxVisibility.Checked;

        private void chckDragMode_CheckedChanged(object sender, EventArgs e)
        {
            crazyMode = !crazyMode;
            player.Stop();
            if (crazyMode)
            {
                string basePath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 9);
                player.SoundLocation =  basePath + @"Sounds\Gator.wav";
                for(int i=0;i<50;i++)
                    SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_DOWN);
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
                SendMessageW(this.Handle, WM_APPCOMMAND, this.Handle, (IntPtr)APPCOMMAND_VOLUME_UP);
                
                player.Play();
            }
        }

        private void chckStopClear_CheckedChanged(object sender, EventArgs e) => dontClear = !dontClear;

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void btnMinimize_Click(object sender, EventArgs e) => this.WindowState = FormWindowState.Minimized;

        private void dragPanel_MouseDown(object sender, MouseEventArgs e) => mouseBefore = new Point(e.X, e.Y);

        private void dragPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point globalMousePosition = Control.MousePosition;
                if (crazyMode)
                    Location = new Point(Location.X + mouseBefore.X - e.X, Location.Y + mouseBefore.Y - e.Y);
                else
                    Location = new Point(globalMousePosition.X - e.X - (mouseBefore.X - e.X), globalMousePosition.Y - e.Y - (mouseBefore.Y - e.Y));
            }
        }

        private void txtbxSmoothness_TextChanged(object sender, EventArgs e)
        {
            string text = txtbxSmoothness.Text;
            Regex reg = new Regex(@"\D");
            if (reg.Match(text).Success || text == "")
            {
                txtbxSmoothness.Text = maxPercentage.ToString();
                return;
            }
            int numberParsed = int.Parse(txtbxSmoothness.Text);
            maxPercentage = Math.Min(Math.Max(10, numberParsed),1000);
            txtbxSmoothness.Text = maxPercentage.ToString();
            timer.Interval = maxPercentage / 10;
            grps.Clear(canvas.BackColor);
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && points.Count == numberOfPoints&& numberOfPoints > 0)
            {
                int index=0;
                double minDistance=double.MaxValue;
                for(int i = 0; i < points.Count; i++)
                {
                    double foundDistance = Distance(e.Location, points[i]);
                    if (foundDistance < minDistance)
                    {
                        index = i;
                        minDistance = foundDistance;
                    }
                }
                Point newPoint = new Point(e.X, e.Y);
                if (!IsOutsideOfCanvas(newPoint))
                {
                    points[index] = newPoint;
                    pointMoved = true;
                    WritePointsInText();
                }
                
            }
        }

        private void btnCreateRandom_Click(object sender, EventArgs e)
        {
            ResetVars();
            List<Point> finalList = new List<Point>();
            for (int i = 0; i < numberOfPoints; i++)
                points.Add(new Point(rnd.Next(2, canvas.Width - 2), rnd.Next(2, canvas.Height - 2)));
            if (numberOfPoints <= 3 || numberOfPoints > 10) 
                return;
            for (int i = 0; i < points.Count; i++)
                for (int j = 0; j < points.Count - 2; j++)
                    if (j != i)
                        for (int k = j + 1; k < points.Count - 1; k++)
                            if (k != j && k != i)
                                for (int l = k + 1; l < points.Count; l++)
                                    if (l != k && l != j && l != i)
                                        if (!IsInsideTriangle(points[l], points[k], points[j], points[i]))
                                            finalList.Add(new Point(points[i].X, points[i].Y));
            
            int centerX = 0;
            int centerY = 0;
            foreach(Point p in finalList)
            {
                centerX += p.X;
                centerY += p.Y;
            }
            Point center = new Point(centerX / finalList.Count, centerY / finalList.Count);
            finalList.Sort(delegate(Point x,Point y) 
            {
                double xAlpha = CalculateAlpha(x, center);
                double yAlpha = CalculateAlpha(y, center);
                if (xAlpha > yAlpha)
                    return 1;
                if (yAlpha > xAlpha)
                    return -1;
                return 0;
            });
            points = new List<Point>(finalList);
        }
        #endregion


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
