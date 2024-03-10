using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Shapes;

namespace TimeLoggerView
{
    public partial class UserDashboard : Window
    {
        // PostgreSQL connection string
        private string connectionString = "Host=localhost;Username=postgres;Password=root;Database=TimeLogger";

        public UserDashboard()
        {
            InitializeComponent();
            PopulateUserGrid();
        }

        private void PopulateUserGrid()
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        MessageBox.Show("Connection established successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Connection failed or closed.");
                    }

                    string sql = "SELECT FirstName, LastName, Username, RoleID, Email FROM Users";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                    {
                        using (NpgsqlDataReader reader = cmd.ExecuteReader())
                        {
                            DataTable dataTable = new DataTable();
                            dataTable.Load(reader);
                            userGrid.ItemsSource = dataTable.DefaultView;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting: " + ex.Message);
            }
        }

        private void create_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO Users (first_name, last_name, username, role, email) " +
                                 "VALUES (@FirstName, @LastName, @Username, @RoleID, @Email)";
                    using (NpgsqlCommand cmd = new NpgsqlCommand(sql, connection))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", firstName_txt.Text);
                        cmd.Parameters.AddWithValue("@LastName", lastName_txt.Text);
                        cmd.Parameters.AddWithValue("@UserName", userName_txt.Text);
                        cmd.Parameters.AddWithValue("@Role", role_txt.Text);
                        cmd.Parameters.AddWithValue("@Email", email_txt.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                // Refresh the user grid after adding the user
                PopulateUserGrid();
            }
            catch (Exception ex)
            {   
                MessageBox.Show("Error inserting: " + ex.Message);
            }
        }
    }
}
