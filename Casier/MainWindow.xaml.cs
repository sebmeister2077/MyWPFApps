using System.Windows;
using System.IO;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System;

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
        private int[] bancnote=new int[7];
        private int suma;
        private int[] solutie = new int[7];
        //StackPanel stack2, stack3, stack4, stack5, stack6, stack7,stack8,stack9;


        private int ReturneazaBancnota(int i)
        {
            //returneaza valoarei bancnotei[i] (pt i=2 bancnota[2]=10 lei)
            switch (i)
            {
                case 0: return 1;
                case 1: return 5;
                case 2: return 10;
                case 3: return 50;
                case 4: return 100;
                case 5: return 200;
                case 6: return 500;
            }
            MessageBox.Show("Eroare fct ReturneazaBancnota()");
            return 0;
        }

        private string GetPath(int i)
        {
            //Returneaza path-ul imaginii bancnotei corespunzatoare
            switch (i)
            {
                case 0: return "Images/un.jpg";
                case 1: return "Images/cinci.jpg";
                case 2: return "Images/zece.jpg";
                case 3: return "Images/cincizeci.jpg";
                case 4: return "Images/osuta.jpg";
                case 5: return "Images/douasute.jpg";
                case 6: return "Images/cincisute.jpg";
            }
            return null;
        }

        private void btngenereaza_Click(object sender, RoutedEventArgs e)
        {
            //algoritm de generare solutie
            //Metoda Greedy
            int auxsum = suma;
            int i;
            int catesunt = 0;//cate imagini vor fi
            for (i = 6; i >= 0; i--)
            {
                while(auxsum >= ReturneazaBancnota(i)&&solutie[i]<bancnote[i])
                {
                    solutie[i]++;
                    auxsum -= ReturneazaBancnota(i);
                    catesunt++;
                }
            }
            if(auxsum>0)
            {
                MessageBox.Show("va lipsesc " + auxsum + " lei pentru a plati suma respectiva");
            }
            else
            {
                int s = 0;
                i = 6;
                while (true)
                {
                    //de fiecare se creaza un nou stackpanel
                    StackPanel auxstack = new StackPanel();
                    auxstack.Orientation = System.Windows.Controls.Orientation.Vertical;
                    stack.Children.Add(auxstack);
                    for (; i >= 0; i--)
                    {
                        while (solutie[i]>0)
                        {
                            var bitmapImage = new BitmapImage();
                            bitmapImage.BeginInit();
                            bitmapImage.UriSource = new Uri(GetPath(i), UriKind.Relative);
                            bitmapImage.EndInit();
                            Image img = new Image();
                            img.Source = bitmapImage;
                            img.Width = 200;
                            img.Height = 100;
                            Thickness marg = img.Margin;
                            marg.Left = 10;
                            marg.Top = 5;
                            marg.Bottom = 5;
                            img.Margin = marg;
                            img.Height = 60;
                            img.Width = 120;
                            #region Add Image to Children
                            //TODO adaugarea unui scroll bar spre dreapta

                            #region Old Switch case
                        /*
                        switch (catesunt/7+1)
                    {
                        //pe 1 coloana
                        case 1:
                            stack1.Children.Add(img);
                            break;
                        case 2:
                            if(catesunt==7)//se adauga un stackpanel
                            {
                                stack2 = new StackPanel();
                                stack2.Orientation = System.Windows.Controls.Orientation.Vertical;
                                stack.Children.Add(stack2);
                            }
                            stack2.Children.Add(img);
                            break;
                        case 3:
                            if (catesunt == 14)//se adauga un stackpanel
                            {
                                stack3 = new StackPanel();
                                stack3.Orientation = System.Windows.Controls.Orientation.Vertical;
                                stack.Children.Add(stack3);
                            }
                            stack3.Children.Add(img);
                            break;
                        case 4:
                            if (catesunt == 21)//se adauga un stackpanel
                            {
                                stack4 = new StackPanel();
                                stack4.Orientation = System.Windows.Controls.Orientation.Vertical;
                                stack.Children.Add(stack4);
                            }
                            stack4.Children.Add(img);
                            break;
                        case 5:
                            if (catesunt == 28)//se adauga un stackpanel
                            {
                                stack5 = new StackPanel();
                                stack5.Orientation = System.Windows.Controls.Orientation.Vertical;
                                stack.Children.Add(stack5);
                            }
                            stack5.Children.Add(img);
                            break;
                        case 6:
                            if (catesunt == 35)//se adauga un stackpanel
                            {
                                stack6 = new StackPanel();
                                stack6.Orientation = System.Windows.Controls.Orientation.Vertical;
                                stack.Children.Add(stack6);
                            }
                            stack6.Children.Add(img);
                            break;
                        case 7:
                            if (catesunt == 42)//se adauga un stackpanel
                            {
                                stack7 = new StackPanel();
                                stack7.Orientation = System.Windows.Controls.Orientation.Vertical;
                                stack.Children.Add(stack7);
                            }
                            stack7.Children.Add(img);
                            break;
                        case 8:
                            if (catesunt == 49)//se adauga un stackpanel
                            {
                                stack8 = new StackPanel();
                                stack8.Orientation = System.Windows.Controls.Orientation.Vertical;
                                stack.Children.Add(stack8);
                            }
                            stack8.Children.Add(img);
                            break;
                        case 9:
                            if (catesunt == 56)//se adauga un stackpanel
                            {
                                stack9 = new StackPanel();
                                stack9.Orientation = System.Windows.Controls.Orientation.Vertical;
                                stack.Children.Add(stack9);
                            }
                            stack9.Children.Add(img);
                            break;
                    }
                    */
                        #endregion
                            auxstack.Children.Add(img);
                            #endregion
                            solutie[i]--;
                            s++;
                            if (s > 0 && s % 7 == 0)
                                break;
                        }
                        if (s > 0 && s % 7 == 0)
                            break;
                    }
                    if (s == catesunt)
                        break;
                }
            }
            //MessageBox.Show("Gata Cica");
        }


        private void PunePeLbl(int i)
        {
            //Scrie in UI cate bancnotei de tipul [i] sunt

            switch(i)
            {
                case 0:
                    lbl1leu.Content = bancnote[i]+"x";
                    break;
                case 1:
                    lbl5lei.Content = bancnote[i]+"x";
                    break;
                case 2:
                    lbl10lei.Content = bancnote[i] + "x";
                    break;
                case 3:
                    lbl50lei.Content = bancnote[i] + "x";
                    break;
                case 4:
                    lbl100lei.Content = bancnote[i] + "x";
                    break;
                case 5:
                    lbl200lei.Content = bancnote[i] + "x";
                    break;
                case 6:
                    lbl500lei.Content = bancnote[i] + "x";
                    break;
            }
        }
        private void btnalg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter =
              "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            dialog.InitialDirectory = "D:\\";
            dialog.Title = "Select a text file";
            DialogResult res= dialog.ShowDialog();
            if (res.ToString() == "OK" && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                bool validFile = true;
                btnalg.Content = "Alege alt fisier";
                flName.FileName = dialog.FileName;
                btngenereaza.IsEnabled = false;//daca se schimba fisierul iar acesta nu este unul bun,nu are trebui sa fie posibila generarea
                StreamReader reader = new StreamReader(dialog.FileName);
                if(!int.TryParse(reader.ReadLine(),out suma))
                {
                    MessageBox.Show("Sum is not a valid number");
                    validFile = false;
                }
                else
                {
                    for (int i=0;i<7;i++)
                    {
                        if (!int.TryParse(reader.ReadLine(), out bancnote[i]))
                        {
                            MessageBox.Show("Invalid number exists on line " + (int)(i + 1));
                            validFile = false;
                        }
                        else
                            PunePeLbl(i);
                    }
                    lblsuma.Content = "Suma=" + suma;
                    if(validFile==true)
                    {
                        btngenereaza.IsEnabled = true;
                    }
                }
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
