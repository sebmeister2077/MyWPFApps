using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bingo
{
    /// <summary>
    /// Interaction logic for PlayerWindow.xaml
    /// </summary>
    public partial class PlayerWindow : Window
    {
        private int playerindex;
        private int[,] matrice = new int[5, 5];
        static Random rnd = new Random();
        private bool[] numere = new bool[100];
        private Label[] labels = new Label[25];
        public short completion;
        public string playername;
        private BingoControl control;
        public PlayerWindow(int playerindex,BingoControl control)
        {
            InitializeComponent();
            this.control = control;
            completion = 0;
            this.playerindex = playerindex;
            this.Title = "Player " + (playerindex + 1).ToString();
            for(int i=0;i<25;i++)
            {
                labels[i] = new Label();
                labels[i].HorizontalAlignment = HorizontalAlignment.Center;
                labels[i].VerticalAlignment = VerticalAlignment.Center;
                labels[i].FontSize = 20;
                Grid.SetColumn(labels[i], i%5);
                Grid.SetRow(labels[i], i / 5+1);
                grid.Children.Add(labels[i]);
                
            }
            playername = "Player " + (playerindex + 1);
            CreareMatrice();
        }
        public void Reset()
        {
            completion = 0;
            numere = new bool[100];
            CreareMatrice();
        }
        private void CreareMatrice()
        {
            int x = 0,aux;
            while(x<25)
            {
                aux = (rnd.Next(1,5000) * (int)Math.Pow(playerindex + 3, rnd.Next() % 3 + 1)) % 99+1;
                if(!numere[aux])
                {
                    numere[aux] = true;
                    labels[x++].Content = aux.ToString();
                }
            }
        }
        private void Bingo(int caz,int x)
        {
            control.Winner(this.Title);
            MessageBox.Show("Bingo!");
            switch(caz)
            {
                case 1:
                    for (int i = (x / 5) * 5; i < (x / 5) * 5 + 5; i++)
                        labels[i].Background = Brushes.LightBlue;
                    break;
                case 2:
                    for (int i = (x / 5) * 5; i < (x / 5) * 5 + 5; i++)
                        labels[i].Background = Brushes.LightBlue;
                    break;
                case 3:
                    for (int i = 0; i < 25; i += 6)
                        labels[i].Background = Brushes.LightBlue;
                    break;
                case 4:
                    for (int i = 4; i < 25; i += 4)
                        labels[i].Background = Brushes.LightBlue;
                    break;
            }
        }
        public void AddNumber(int nr)
        {
            currentnmbr.Content = "Current number added:" + nr.ToString();
            int x = 0;
            foreach (var l in labels)
                if (l.Content.ToString() == nr.ToString())
                {
                    completion++;
                    lblcompl.Content = completion * 4 + "%";
                    l.Foreground = Brushes.Green;
                    break;
                }
                else
                    x++;
            if (x < 25)
            {
                bool ok = true; ;
                //vertical
                for (int i = x % 5; i < 25; i += 5)
                    if (labels[i].Foreground != Brushes.Green)
                        ok = false;
                if (ok)
                   Bingo(1,x);
                //orizontal
                ok = true;
                for (int i = (x / 5) * 5; i < (x / 5) * 5 + 5; i++)
                    if (labels[i].Foreground != Brushes.Green)
                        ok = false;
                if (ok)
                    Bingo(2,x);
                if (x % 5 == x / 5)//este pe diagPrinc
                {
                    ok = true;
                    for (int i = 0; i < 25; i += 6)
                        if (labels[i].Foreground != Brushes.Green)
                            ok = false;
                    if (ok)
                        Bingo(3,x);
                }
                if (4 - (x % 5) == x / 5)//este pe DiagSec
                {
                    ok = true;
                    for (int i = 4; i < 25; i += 4)
                        if (labels[i].Foreground != Brushes.Green)
                            ok = false;
                    if (ok)
                        Bingo(4,x);
                }
            }
        }
    }
}
