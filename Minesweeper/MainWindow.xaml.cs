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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Minesweeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int n,bombs;
        public MainWindow()
        {
            InitializeComponent();
            InitializeLayout();
        }
        void InitializeLayout()
        {
            ComboBoxItem c = (ComboBoxItem)combobox.SelectedItem;
            switch(c.Content.ToString())
            {
                case "Easy":
                    n = 20;
                    bombs = 20;
                    break;
                case "Normal":
                    n = 50;
                    bombs = 50;
                    break;
                case "Hard":
                    n = 100;
                    bombs = 100;
                    break;
            }
            for (int i = 0; i <= n; i++)
            {
                ColumnDefinition col = new ColumnDefinition();
                col.Width =new GridLength("*");
                grid.ColumnDefinitions.Add(); 
            }
        }
    }
}
