using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Grafic_functie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private void DeseneazaAxe()
        {
            Line linie;
            for (int i = 0; i < 600; i += 39)
            {
                linie = new Line();
                linie.Stroke = System.Windows.Media.Brushes.Black;
                linie.X1 = i;
                linie.X2 = i + 15;
                linie.Y1 = canvas.Height / 2;
                linie.Y2 = canvas.Height / 2;
                linie.StrokeThickness = 1;
                canvas.Children.Add(linie);
            }
            for (int i = 0; i < 600; i += 39)
            {
                linie = new Line();
                linie.Stroke = System.Windows.Media.Brushes.Black;
                linie.X1 = canvas.Width / 2;
                linie.X2 = canvas.Width / 2;
                linie.Y1 = i;
                linie.Y2 = i + 15;
                linie.StrokeThickness = 1;
                canvas.Children.Add(linie);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            DeseneazaAxe();
        }
        private string ChangeX(string expression,double i)
        {
            string str = "";
            foreach(char c in expression)
            {
                if (c == 'x')
                    str += i.ToString();
                else
                    str += c.ToString();
            }
            return str;
        }
        private void UpdateFunction(string str)
        {
            MessageBox.Show("Functia:" + str);
            canvas.Children.Clear();
            DeseneazaAxe();
            Line linie;
            double d = 20;
            double aux= Library.Expression.ReturnValueOfExpression(ChangeX(txtboxexpr.Text, (-canvas.Width/2-1)/d)) *d;
            for (double i = -canvas.Width / 2; i < canvas.Width / 2; i++)
            {
                linie = new Line();
                linie.Stroke = System.Windows.Media.Brushes.Black;
                linie.X1 = i - 1 + canvas.Width / 2;
                linie.X2 = i + canvas.Width / 2;
                linie.Y1 = canvas.Height / 2 - aux;
                aux = Library.Expression.ReturnValueOfExpression(ChangeX(str, i/d))*d;
                linie.Y2 = canvas.Height / 2 - aux;
                linie.StrokeThickness = 1;
                canvas.Children.Add(linie);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateFunction(txtboxexpr.Text);
        }

        private void btnfourier_Click(object sender, RoutedEventArgs e)
        {
            if(lstbx.SelectedIndex>=0)
            {
                string str = "(4*PI)*(";
                var x = lstbx.SelectedItem as ListBoxItem;
                for (int i=1;i<int.Parse(x.Content.ToString())+1;i++)
                {
                    if (i != 1)
                        if (i % 2 == 0)
                            str += "-";
                        else
                            str += "+";
                    str += "(cos("+(2*i-1).ToString()+"*PI*x)/"+ (2 * i - 1).ToString()+")";
                }
                str += ")";
                UpdateFunction(str);
            }
        }
    }
}
