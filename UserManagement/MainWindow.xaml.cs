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
        FetchData();
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

    private void FetchData()
    {
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
        using SqlConnection conn = new(connectionString);

        conn.Open();

        string query = "SELECT * FROM Users";
        SqlCommand command = new(query, conn);

        SqlDataReader reader = command.ExecuteReader();
        if (!reader.HasRows) return;

        List<List<object>> values = new() { };


        while (reader.Read())
        {

            List<object> rowValues = new() { };
            for (int i = 0; i < reader.FieldCount; i++)
            {
                object value = reader.GetValue(i);
                Type dataType = reader.GetFieldType(i);
                rowValues.Add(value);
            }
            values.Add(rowValues);
        }



        reader.Close();


    }
}
