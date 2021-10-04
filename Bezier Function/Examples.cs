using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezier_Function
{
    public partial class Examples : Form
    {
        public Examples(Delegate callback)
        {
            InitializeComponent();
            Callback = callback;
        }

        public Examples(SpecialObject savedArt,Delegate callback) : this(callback) => objReceived = new SpecialObject(savedArt);

        private Delegate Callback;
        private SpecialObject objReceived;
        private string selected = "";
        private List<SpecialObject> listObjects;
        string basePath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 9)+ @"Data\";


        private void Examples_Load(object sender, EventArgs e)
        {
            if (objReceived != null && objReceived.Points.Length > 2) 
            {
                string finalPath = basePath + objReceived.Title + ".txt";
                

                File.Create(finalPath).Close();
                TextWriter tw = new StreamWriter(finalPath);

                tw.WriteLine(objReceived.Title);
                tw.WriteLine(Convert.ToInt32(objReceived.IsRandom).ToString());
                tw.WriteLine(objReceived.Count.ToString());
                tw.WriteLine(objReceived.Points);
                tw.WriteLine(ImageToString(new Bitmap(objReceived.Image)));
                selected = objReceived.Title;
                tw.Dispose();
            }
            FetchObjects();
            RenderInitialData();
        }

        #region Functions
        private void RenderInitialData()
        {
            int index = listBox.Items.IndexOf(selected);
            if (index < 0)
                index++;
            listBox.SelectedIndex = index;
            picBox.Image = listObjects[index].Image;
        }

        private void FetchObjects()
        {
            listObjects = new List<SpecialObject>();
            string[] fileNames = Directory.GetFiles(basePath);

            for (int i = 0; i < fileNames.Length; i++)
                fileNames[i] = fileNames[i].Substring(fileNames[i].LastIndexOf(@"\"));

            foreach(string name in fileNames)
            {
                TextReader tr = new StreamReader(basePath + name);
                SpecialObject obj = new SpecialObject();
                obj.Title = tr.ReadLine();
                obj.IsRandom = int.Parse(tr.ReadLine()) > 0 ? true : false;
                obj.Count = int.Parse(tr.ReadLine());
                StringBuilder bobTheBuilder = new StringBuilder();
                for (int i = 0; i < obj.Count; i++)
                    bobTheBuilder.AppendLine(tr.ReadLine());
                obj.Points = bobTheBuilder.ToString().Replace("\r","");
                obj.Points = obj.Points.Substring(0, obj.Points.Length - 1);
                obj.Image = StringToImage(tr.ReadToEnd());

                tr.Dispose();
                listBox.Items.Add(obj.Title);
                listObjects.Add(obj);
            }
        }
        private string ImageToString(Bitmap bitmap)
        {
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] imageBytes = stream.ToArray();
            return Convert.ToBase64String(imageBytes,0,imageBytes.Length);
        }

        private Bitmap StringToImage(string str)
        {
            byte[] imageBytes = Convert.FromBase64String(str);
            TypeConverter tc = TypeDescriptor.GetConverter(typeof(Bitmap));
            return (Bitmap)tc.ConvertFrom(imageBytes);
        }

        private void Swap<T>(T a,T b)
        {
            T aux = b;
            b = a;
            a = aux;
        }

        private void InfoBoxChanged(bool? isRandom,string points,Bitmap image)
        {
            lblIsRandom.Text = "Randomly Generated:" + isRandom.ToString();
            picBox.Image = image;
            txtbxPoints.Text = points;
        }
        #endregion


        #region Events

        private void listExamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Math.Max(0, listBox.SelectedIndex);
            SpecialObject obj = new SpecialObject(listObjects[index]);
            InfoBoxChanged(obj.IsRandom, obj.Points, obj.Image);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            File.Delete(basePath + listObjects[index].Title + ".txt");
            listObjects.RemoveAt(index);
            listBox.Items.RemoveAt(index);
            InfoBoxChanged(null, "", null);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            int index = listBox.SelectedIndex;
            Callback.DynamicInvoke(new SpecialObject(listObjects[index]));
            this.Close();
        }
        #endregion
    }
}
