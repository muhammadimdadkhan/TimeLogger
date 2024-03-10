using Common.Enums;
using Common.ResponseModels;
using Microsoft.Extensions.DependencyInjection;
using Model.Interface;
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
using System.Windows.Shapes;
using TimeLoggerView.ViewModels;

namespace TimeLoggerView
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        IAuthenticationService _authenticationService { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            // Resolve the service from App's ServiceProvider
            _authenticationService = ((App)Application.Current).ServiceProvider.GetService<IAuthenticationService>();

            // Initialize the ViewModel with the service
            DataContext = new LoginWindowViewModel(_authenticationService);
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
           Response response=  _authenticationService.Login(txtUser.Text,txtPass.Password);
            if (response.Status.Equals(ResponseStatus.Success))
            {
                SessionDetails.loggedInUser = (Model.ModelSql.User)response.Data;
                MainWindow userWindow = new MainWindow();
                userWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show(response.Message);
            }
        }

        private void ResetTxt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
