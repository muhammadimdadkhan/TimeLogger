using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
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

namespace TimeLoggerView.Windows
{
    public partial class AddProjectForm : Window
    {
        // Connection string to your PostgreSQL database
        private string connectionString = ConfigurationManager.ConnectionStrings["TimeLoggerDatabase"].ConnectionString;

        public AddProjectForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to insert data into the Project table
                    string query = "INSERT INTO public.Projects (ProjectName, Description) VALUES (@ProjectName, @Description)";

                    using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                    {
                        // Parameters for the query
                        command.Parameters.AddWithValue("@ProjectName", txtProjectname.Text);
                        command.Parameters.AddWithValue("@Description", txtDescription.Text);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Data inserted successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}
