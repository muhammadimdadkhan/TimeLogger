using Model.ModelSql;
using Session;
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
using System.Windows.Shapes;

namespace TimeLoggerView
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        public UserWindow()
        {
            InitializeComponent();

            // Initialize grid with dummy data
            List<User> users = new List<User>()
            {
                SessionDetails.loggedInUser    
            };
            UserGrid.ItemsSource = users;
        }

        // Event handler for navigation buttons
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Handle navigation button click
        }

        // Event handler for sign out button
        private void SignOutButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle sign out button click
        }

        // Event handler for add button
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle add button click
        }

        // Event handler for edit button
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle edit button click
        }

        // Event handler for delete button
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle delete button click
        }
        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "Search...")
            {
                SearchBox.Text = "";
                SearchBox.Foreground = Brushes.Black; // Change text color to black when focused
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchBox.Text))
            {
                SearchBox.Text = "Search...";
                SearchBox.Foreground = Brushes.Gray; // Change text color to gray when not focused
            }
        }

    }
}
