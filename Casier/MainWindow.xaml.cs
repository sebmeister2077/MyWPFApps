using System.Windows;
using System.IO;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

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
         private StreamReader fs;
        private OpenFileDialog flName=new OpenFileDialog();

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
            DialogResult res= dialog.ShowDialog();
            if (res.ToString() == "OK" && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                btnalg.Content = "Alege alt fisier";
                btngenereaza.IsEnabled = true;
                flName.FileName = dialog.FileName;
            }
        }

        private void btninfo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Alegeti un fisier text care contine doar numere si spatii astfel incat:\n" +
                "Pe primul rand sa fie Suma\n"+
                "Pe urmatoarele 7 randuri cate un numar: cate bancnote de acel tip exista(1,5,10,50,....).");
        }
    }
}
