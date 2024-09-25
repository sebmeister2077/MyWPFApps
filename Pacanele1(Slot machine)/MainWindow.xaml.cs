using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Timers;

namespace Pacanele1_Slot_machine_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// bar   1
        /// bell   2
        /// blank   3
        /// clover  4
        /// coins   5
        /// crown   6
        /// diamond 7
        /// die     8
        /// grapes  9
        /// horseshoe 10
        /// seven     11
        /// sourcherry 12 
        /// strawberry 13
        /// </summary>
        bool gameStart = false;
        private int coins;
        private int freeSpins;
        private int diamonds;
        private int replaces;
        private int totalSpins;
        private int[] retineImg = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int spent;
        private int multiplier;
        private int score;

        public void Initialize()
        {
            coins = 300;
            freeSpins = 3;
            replaces = 0;
            diamonds = 0;
            totalSpins = 0;
            if (freeSpins > 0)
                spin.Content = "Free Spins" + freeSpins.ToString();
            combbox.SelectedItem = combbox.Items[0];
            lblSC.Content = "10SC";
            spent = 10;
            multiplier = 1;
            lblcoins.Content = "SCoins:" + coins.ToString();
            lblscore.Content = "Current Score:0";
        }
        private static BitmapImage GetImage(string imageUri)
        {
            var bitmapImage = new BitmapImage();

            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(imageUri, UriKind.Relative);
            bitmapImage.EndInit();
            return bitmapImage;
        }
        public void GameOver()
        {
            MessageBox.Show("Game over.");
            AddScore window = new AddScore();
            window.lblscore.Content = "Your Score:" + score;
            window.score = score;
            window.Show();
            this.Close();
        }
        #region Change ImgSource
        public void Put(int poz, string path, string data)
        {
            switch (poz)
            {

                case 1:
                    img1.Source = GetImage(path);
                    img1.Tag = data;
                    break;
                case 2:
                    img2.Source = GetImage(path);
                    img2.Tag = data;
                    break;
                case 3:
                    img3.Source = GetImage(path);
                    img3.Tag = data;
                    break;
                case 4:
                    img4.Source = GetImage(path);
                    img4.Tag = data;
                    break;
                case 5:
                    img5.Source = GetImage(path);
                    img5.Tag = data;
                    break;
                case 6:
                    img6.Source = GetImage(path);
                    img6.Tag = data;
                    break;
                case 7:
                    img7.Source = GetImage(path);
                    img7.Tag = data;
                    break;
            }
        }
        #endregion
        #region SPIN
        public void Spin(int pozitia)
        {
            int aux = rnd.Next();
            if (aux % 1137 == 0)
            {
                //seven
                retineImg[pozitia - 1] = 11;
                Put(pozitia, "Images/seven.jpg", "seven");
            }
            else
                if (aux % 555 == 0)
            {
                //die
                retineImg[pozitia - 1] = 8;
                Put(pozitia, "Images/die.jpg", "die");
            }
            else
                if (aux % 5149 == 0)
            {
                //diamond
                retineImg[pozitia - 1] = 7;
                Put(pozitia, "Images/diamond.jpg", "diamond");
            }
            else
                if (aux % 777 == 0)
            {
                //coins
                retineImg[pozitia - 1] = 5;
                Put(pozitia, "Images/coins.jpg", "coins");
            }
            else
                if (aux % 22229 == 0)
            {
                //horseshoe
                retineImg[pozitia - 1] = 10;
                Put(pozitia, "Images/horseshoe.jpg", "horseshoe");
            }
            else
                if (aux % 13 == 0)
            {
                //bar
                retineImg[pozitia - 1] = 1;
                Put(pozitia, "Images/bar.jpg", "bar");
            }
            else
                if (aux % 19 == 0)
            {
                //clover
                retineImg[pozitia - 1] = 4;
                Put(pozitia, "Images/clover.jpg", "clover");

            }
            else
            {
                //fructe
                if (aux % 3 == 0)
                {
                    retineImg[pozitia - 1] = 12;
                    Put(pozitia, "Images/sourcherry.jpg", "sourcherry");
                }
                else
                    if (aux % 2 == 0)
                {
                    Put(pozitia, "Images/grapes.jpg", "grapes");
                    retineImg[pozitia - 1] = 9;
                }
                else
                {
                    retineImg[pozitia - 1] = 13;
                    Put(pozitia, "Images/strawberry.jpg", "strawberry");
                }
            }
            if (pozitia < 7)
                Spin(pozitia + 1);
        }
        #endregion

        #region Results
        public void CheckResults()
        {
            short sevens = 0, dies = 0, hshoes = 0, clovers = 0, bars = 0, fruit1 = 0, fruit2 = 0, fruit3 = 0, fruits = 0;
            bool oneOfAKindFruit = false;
            for (int i = 0; i < 7; i++)
            {
                switch (retineImg[i])
                {
                    case 1:
                        bars++;
                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:
                        clovers++;
                        break;
                    case 5:
                        coins = coins + 2 * spent;
                        score += 2 * spent;
                        MessageBox.Show("Coins Found!");
                        break;
                    case 6:

                        break;
                    case 7:
                        diamonds++;
                        score += 1000;
                        lbldiamonod.Content = ":" + diamonds;
                        break;
                    case 8:
                        dies++;
                        break;
                    case 9:
                        fruit1++;
                        fruits++;
                        break;
                    case 10:
                        hshoes++;
                        break;
                    case 11:
                        sevens++;
                        break;
                    case 12:
                        fruit2++;
                        fruits++;
                        break;
                    case 13:
                        fruit3++;
                        fruits++;
                        break;
                }
            }
            if (sevens == 7)//wins jackpot
            {
                Hooray newWindow = new Hooray();
                newWindow.Show();
                score += 80000;
                coins += 80000;
            }
            if (hshoes == 7 || (hshoes + bars == 7))
            {
                replaces++;
                lblreplace.Content = ":" + replaces + "(Replaces left)";
            }
            if (dies == 7 || (clovers + bars == 7))
            {
                freeSpins += 7;
                spin.Content = "Free Spins:" + freeSpins.ToString();
            }
            if (clovers == 7 || (clovers + bars == 7))
            {
                coins += 5000 * multiplier;
                score += 5000;
            }
            if (fruit1 == 7 || (fruit1 + bars == 7))
            {
                coins += 50 * multiplier;
                score += 50;
                oneOfAKindFruit = true;
            }
            if (fruit2 == 7 || (fruit2 + bars == 7))
            {
                coins += 50 * multiplier;
                score += 50;
                oneOfAKindFruit = true;
            }
            if (fruit3 == 7 || (fruit3 + bars == 7))
            {
                coins += 50 * multiplier;
                score += 50;
                oneOfAKindFruit = true;
            }
            if (oneOfAKindFruit == false && (fruits == 7 || (fruits + bars == 7)))
            {
                coins += 5 * multiplier;
                score += 5;
            }
            lblcoins.Content = "SCoins:" + coins;
            lblscore.Content = "Current Score:" + score.ToString();
        }

        #endregion
        private void spin_Click(object sender, RoutedEventArgs e)
        {
            if (gameStart == false)
            {
                gameStart = true;
                Initialize();
            }
            else
            {
                if (freeSpins > 0)
                {
                    freeSpins--;
                    spin.Content = "Free spins:" + freeSpins.ToString();
                    if (freeSpins == 0)
                        spin.Content = "Spin again";
                }
                else
                {
                    coins -= spent;
                }
                if (coins < 0)//game over
                {
                    GameOver();
                    gameStart = false;
                }
                else
                {
                    Spin(1);
                    totalSpins++;
                    CheckResults();
                }
            }

        }

        private void rewards_Click(object sender, RoutedEventArgs e)
        {
            var mywindow = new Rewards();
            mywindow.Show();
        }

        private void getcoins_Click(object sender, RoutedEventArgs e)
        {
            // Reset();
            Hooray newWindow = new Hooray();
            newWindow.Show();
        }


        private void combbox_DropDownClosed(object sender, EventArgs e)
        {
            switch (combbox.Text)
            {
                case "x1":
                    lblSC.Content = "10SC";
                    spent = 10;
                    multiplier = 1;
                    break;
                case "x2":
                    lblSC.Content = "15SC";
                    spent = 15;
                    multiplier = 2;
                    break;
                case "x5":
                    lblSC.Content = "30SC";
                    spent = 30;
                    multiplier = 5;
                    break;
                case "x10":
                    lblSC.Content = "50SC";
                    spent = 50;
                    multiplier = 10;
                    break;
                case "x50":
                    lblSC.Content = "220SC";
                    spent = 220;
                    multiplier = 50;
                    break;
            }
        }

        private void ldrbrd_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddScore();
            window.confirm.Content = "OK";
            window.txtbox.IsReadOnly = true;
            window.lblname.Visibility = Visibility.Hidden;
            window.txtbox.Visibility = Visibility.Hidden;
            window.lblscore.Visibility = Visibility.Hidden;
            window.Show();
        }

        private void restart_Click(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
    }
}
