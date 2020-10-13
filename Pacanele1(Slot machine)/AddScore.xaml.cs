using System.Windows;
using PlayerData;

namespace Pacanele1_Slot_machine_
{
    /// <summary>
    /// Interaction logic for AddScore.xaml
    /// </summary>
    public partial class AddScore : Window
    {
        public AddScore()
        {
            InitializeComponent();
            foreach(Player plr in PlayerData.Player.playerList)
            {
                grp.Content = grp.Content + "Name:" + plr.name + "  Score:" + plr.score + "\n";
            }

        }
        public int score;
        private void confirm_Click(object sender, RoutedEventArgs e)
        {
            if (confirm.Content == "OK")
            {
                MainWindow window = new MainWindow();
                window.Show();
                this.Close();
            }
            else
            if (txtbox.Text.Length >= 3 && txtbox.Text.Length <= 30)
            {

                Player newplr = new Player(score, txtbox.Text);
                newplr.AddPlayer();
                confirm.Content = "OK";
            }
            else
                invalidtext.Visibility = Visibility.Visible;

        }
    }
}
