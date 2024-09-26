using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace UserManagement;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        //InsertData();
        var users = FetchData();
        dataGrid.ItemsSource = users;
    }

    private void InsertData()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        using SqlConnection conn = new(connectionString);

        conn.Open();

        string query = "INSERT INTO Users ([UserName],[IsAdmin],[Password]) VALUES('Sebas',1,'password')";
        SqlCommand command = new(query, conn);

        command.ExecuteNonQuery();


    }

    private List<User> FetchData()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        using SqlConnection conn = new(connectionString);

        conn.Open();

        string query = "SELECT [Id],[IsAdmin],[UserName] FROM Users";
        SqlCommand command = new(query, conn);

        SqlDataReader reader = command.ExecuteReader();

        if (!reader.HasRows) return new List<User>();

        List<User> users = new() { };


        while (reader.Read())
        {

            User user = new()
            {
                Id = reader.GetInt32(0),
                IsAdmin = reader.GetBoolean(1),
                UserName = reader.GetString(2),
            };
            users.Add(user);
        }



        reader.Close();
        return users;

    }

    private void dataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        var element = e.EditingElement;
        if (element is TextBox textBoxElement)
        {

        }
    }

    private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {

    }
}
