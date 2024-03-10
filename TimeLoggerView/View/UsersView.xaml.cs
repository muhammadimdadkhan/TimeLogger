using Microsoft.Extensions.DependencyInjection;
using Model.ModelSql;
using Service.Interface;
using Service.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeLoggerView.ViewModels;

namespace TimeLoggerView.View
{
    /// <summary>
    /// Interaction logic for Customers.xaml
    /// </summary>
    public partial class UsersView : UserControl
    {
        IUserService _userService { get; set; }

        // Resolve the service from App's ServiceProvider
        public UsersView()
        {
            InitializeComponent();

            _userService = ((App)Application.Current).ServiceProvider.GetService<IUserService>();

            // Initialize the ViewModel with the service
            DataContext = new UsersVM(_userService);

            List<User> users = new List<User>()
            {
                SessionDetails.loggedInUser
            };
            UserGrid.ItemsSource = users;
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
    }
}
