using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
        private const string FILE_TYPE = ".xml";
        private string basePath;
        System.Media.SoundPlayer player;
        private delegate void Callback(SpecialObject obj);

        static bool drawExtras = false;
        static bool dontClear = false;
        static bool crazyMode = false;
        static Point mouseBefore;
        static bool pointMoved = false;
        static bool pointAdded = false;
        static Random rnd = new Random();
        static int hash = 0;

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

            basePath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 9);
            player = new System.Media.SoundPlayer();
            ToolTip ToolTip1 = new ToolTip();
            ToolTip1.SetToolTip(lblNumberOfPoints, "Enter number of points and then click on canvas");
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


        private void HandleGameStateChange(bool? value = null)
        {
            if (value != null)
                gameState = (bool)!value;
            btnGameState.Text = gameState ? "Start" : "Stop";
            btnGameState.ForeColor = gameState ? Color.LawnGreen: Color.Red;
            gameState = !gameState;
            if (gameState)
                timer.Start();
            else
                timer.Stop();
        }

        #region Math

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

        private int ReturnRange(double number, double min, double max) => (int)Math.Max(Math.Min(number, max), min);

        private double Distance(Point p1, Point p2) => Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        
        private bool IsOutsideOfCanvas(Point p) => p.X < 1 || p.Y < 1 || p.X > canvas.Width || p.Y > canvas.Height;
        #endregion

        #endregion

        #region RequiredEvents
        private void btnGameState_Click(object sender, EventArgs e)
        {
            string text = txtbxSmoothness.Text;
            Regex reg = new Regex(@"\D");
            if (reg.Match(text).Success || text == "")
            {
                txtbxSmoothness.Text = maxPercentage.ToString();
                return;
            }
            int numberParsed = int.Parse(txtbxSmoothness.Text);
            maxPercentage = Math.Min(Math.Max(10, numberParsed), 1000);
            txtbxSmoothness.Text = maxPercentage.ToString();
            timer.Interval = maxPercentage / 10;
            grps.Clear(canvas.BackColor);

            HandleGameStateChange();
        }

        private void txtbxPoints_TextChanged(object sender, EventArgs e)
        {
            string text = txtbxPoints.Text;
            string[] lines = text.Split('\n');
            Regex regLine = new Regex(@"^\([0-9]+,[0-9]+\)$");
            int pointsFound = 0;
            foreach (string line in lines)
                pointsFound += regLine.Match(line).Success ? 1 : 0;


            bool resetVars = !pointMoved && !pointAdded;
            if (resetVars)
                ResetVars();

            alreadyReset = true;
            txtbxNumber.Text = pointsFound.ToString();
            numberOfPoints = pointsFound;
            if (resetVars)
            foreach (string line in lines)
                if (regLine.Match(line).Success)
                    points.Add(line.StringToPoint());
            pointMoved = false;
            pointAdded = false;

            if (Math.Max(lines.Length - 1, 0) != pointsFound) 
                ShowWarningMessage();
            else
                ShowWarningMessage(false);
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
                pointAdded = true;
            }
            if (points.Count == numberOfPoints)
                WritePointsInText();
        }
        #endregion

        #region ExtraFunctions

        public string PointToString(Point p) => "(" + p.X.ToString() + "," + p.Y.ToString() + ")";

        private void WritePointsInText()
        {
            StringBuilder bobTheBuilder = new StringBuilder();
            foreach (Point p in points)
                bobTheBuilder.AppendLine(PointToString(p));
            txtbxPoints.Text = bobTheBuilder.ToString();
        }

        private void CreateRandomPoints()
        {
            ResetVars();
            Point[] pointArr = new Point[numberOfPoints];
            pointArr[0] = new Point(rnd.Next(2, canvas.Width - 2), rnd.Next(2, canvas.Height - 2));
            const int multiplier = 3;
            const int amplitude = 100;
            const int offset = 70;
            for (int i = 1; i < numberOfPoints; i++)
            {
                double x = pointArr[i - 1].X;
                double y = pointArr[i - 1].Y;
                double w = canvas.Width;
                double h = canvas.Height;
                pointArr[i] = new Point(ReturnRange(rnd.Next((int)(x - multiplier * (amplitude * Math.Log10(x) - offset)), (int)(x + multiplier * (amplitude * Math.Log10(-x + w) - offset))), 5, w - 5),
                    ReturnRange(rnd.Next((int)(y - multiplier * (amplitude * Math.Log10(y) - offset)), (int)(y + multiplier * (amplitude * Math.Log10(-y + h) - offset))), 5, h - 5));
            }
            points = pointArr.ToList();
            hash = points.GetHashCode();
        }

        private void GotResponse(SpecialObject obj)
        {
            txtbxTitle.Text = obj.Title;
            ConvertFromStringToSpecialObject(obj.Points);
        }

        private void  ConvertFromStringToSpecialObject(string pointsStr)
        {
            points = new List<Point>();
            string[] pointArray = pointsStr.Split('\n');
            foreach(string p in pointArray)
            {
                string[] parts = p.Split(',');
                points.Add(new Point(int.Parse(parts[0].Substring(1, parts[0].Length - 1)), int.Parse(parts[1].Substring(0, parts[1].Length - 1))));
            }
            numberOfPoints = points.Count;
            WritePointsInText();
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
            IntPtr wParam, IntPtr lParam);


        #region OnComponents
        private void ShowWarningMessage(bool value = true)
        {
            if (value)
                labelPointsError.Text = "Invalid points.";
            else
                labelPointsError.Text = "";
        }

        #endregion

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
            HandleGameStateChange(false);
            
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
                    pointMoved = true;
                }
            }
        }

        private void btnCreateRandom_Click(object sender, EventArgs e)
        {
            ResetVars();
            CreateRandomPoints();
            WritePointsInText();
        }

        private void btnExamples_Click(object sender, EventArgs e)
        {
            Callback waitForResponse = GotResponse;
            Form exampleForm = new Examples(waitForResponse);
            HandleGameStateChange(false);
            exampleForm.Show();
        }

        private void btnSaveState_Click(object sender, EventArgs e)
        {
            string title = txtbxTitle.Text;
            string[] fileNames = Directory.GetFiles(basePath+ @"Data\");
            if (title == "") 
            {
                MessageBox.Show("Empty Title");
                return;
            }
            if (fileNames.Contains(title + FILE_TYPE))
            {
                MessageBox.Show("This title is already token");
                return;
            }
            bool isRandom = hash == points.GetHashCode();
            Callback waitForResponse = GotResponse;
            Examples exampleForm = new Examples(new SpecialObject(bmp,txtbxPoints.Text,numberOfPoints,title,isRandom),waitForResponse);
            HandleGameStateChange(false);
            exampleForm.Show();
            txtbxTitle.Text = "";
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
