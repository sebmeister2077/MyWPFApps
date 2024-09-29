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
        ///InsertData();
        FetchAndShowUsers();
    }

    private void InsertData()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        using SqlConnection conn = new(connectionString);

        conn.Open();

        string query = "INSERT INTO Users ([UserName],[IsAdmin],[Password]) VALUES('Cioabi',0,'password1')";
        SqlCommand command = new(query, conn);

        command.ExecuteNonQuery();


    }

    private void FetchAndShowUsers()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        using SqlConnection conn = new(connectionString);

        conn.Open();

        string query = "SELECT [Id],[IsAdmin],[UserName] FROM Users";
        SqlCommand command = new(query, conn);

        SqlDataReader reader = command.ExecuteReader();

        if (!reader.HasRows) return;

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
        dataGrid.ItemsSource = users;
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
        if (e.RemovedItems.Count == 0) return;
        if (!(e.RemovedItems[0] is User editedUser)) return;
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        using SqlConnection conn = new(connectionString);

        conn.Open();

        int isAdminBit = editedUser.IsAdmin ? 1 : 0;
        string query = $"UPDATE Users SET [IsAdmin]={isAdminBit},[UserName]='{editedUser.UserName}' WHERE [Id] = {editedUser.Id}";
        SqlCommand command = new(query, conn);

        command.ExecuteNonQuery();

    }
}
