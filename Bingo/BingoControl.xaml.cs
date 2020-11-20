using System;
using System.Windows;

namespace Bingo
{
    /// <summary>
    /// Interaction logic for BingoControl.xaml
    /// </summary>
    public partial class BingoControl : Window
    {
        private PlayerWindow[] windows;
        static Random rnd = new Random();
        private bool[] numere= new bool[100];
        private int playercount;
        private int numbersleft;
        private bool getNextNumber = true;
        public BingoControl(int index)
        {
            InitializeComponent();
            playercount = index +2;
            windows = new PlayerWindow[playercount];
            for (int i = 0; i < playercount; i++)
            {
                windows[i] = new PlayerWindow(i,this);
                windows[i].Show();
            }
            numbersleft = 99;
            lblnumbleft.Content = "Numbers left:" + numbersleft;
        }
        public void Winner(string winnername)
        {
            lblfirst.Content = "Winner:" + winnername.ToString();
            btnnumber.Content = "Joc nou";
        }
        private void btnnumber_Click(object sender, RoutedEventArgs e)
        {
            if(getNextNumber)//este inca in joc
            {
                int numarGenerat;
                do
                {
                    numarGenerat = rnd.Next(1, 100);
                } while (numere[numarGenerat]);
                for(int i=0;i<playercount;i++)
                    windows[i].AddNumber(numarGenerat);
                numbersleft--;
                numere[numarGenerat] = true;
                lblnumbleft.Content = "Numbers left:" + numbersleft;
                lblnumberfound.Content = numarGenerat.ToString();
                int index = 0, maxim = 0;
                for(int i=0;i< playercount;i++)
                    if(windows[i].completion>maxim)
                    {
                        maxim = windows[i].completion;
                        index = i;
                    }
                lblfirst.Content = "Leader: " + windows[index].Title;
                lblcompletion.Content = "With Completion:" + maxim *4 + "%";
                if(numbersleft==0)
                {
                    btnnumber.Content = "Joc nou";
                    getNextNumber = false;
                }
            }
            else
            {
                btnnumber.Content = "Next number";
                numbersleft = 99;
                getNextNumber = true;
                numere = new bool[100];
                foreach (var wind in windows)
                    wind.Reset();
            }
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var firstwindow = new MainWindow();
            firstwindow.Show();
            foreach (PlayerWindow wind in windows)
                wind.Close();
            this.Close();
        }
    }
}
