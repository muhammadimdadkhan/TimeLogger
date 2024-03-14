using Common.Enums;
using Common.Messages;
using Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Model.ModelSql;
using Service.Interface;
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
using TimeLoggerView.ViewModels;

namespace TimeLoggerView.Windows
{
    /// <summary>
    /// Interaction logic for AddUserForm.xaml
    /// </summary>
    public partial class AddUserForm : Window
    {
        IUserService _userService { get; set; }

        public AddUserForm()
        {
            InitializeComponent();
            _userService = ((App)Application.Current).ServiceProvider.GetService<IUserService>();
           // cmbRole.ItemsSource = _userService.GetRolesForDropdown();
          // cmbRole.ItemsSource = Constants.Roles;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           User user= new User
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Password = txtPassword.Password,
                Email = txtEmail.Text,
                Username = txtUsername.Text,
                IsActive = true,
                Designation = txtDesignation.Text,
                RoleID  = Convert.ToInt32(((ComboBoxItem)cmbRole.SelectedItem).Tag)
           };
         bool result=   _userService.AddUser(user);
            if (result)
            {
                MessageBox.Show(ResponseMessage.Messages[MessageType.AddSuccess]);
            }
            else
            {
                MessageBox.Show(ResponseMessage.Messages[MessageType.AddFailure]);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
