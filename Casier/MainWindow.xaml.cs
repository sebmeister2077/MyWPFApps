using System.Windows;
using System.IO;
using Microsoft.Win32;

namespace Casier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        FileStream fs;

        private void btngenereaza_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnalg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
              "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = "C:\\";
            dialog.Title = "Select a text file";
            if (dialog.ShowDialog() == DialogResult.HasValue)
            {
                string fname = dialog.FileName;
                btngenereaza.IsEnabled = true;

            }
        }

        private void btninfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Alegeti un fisier text care contine doar numere si spatii astfel incat:\n" +
                "Pe primul rand sa fie Suma\n"+
                "Pe urmatoarele 7 randuri cate 2 numere: tipul bancnotei si cate bancnote de acel tip exista.");
        }
    }
}
