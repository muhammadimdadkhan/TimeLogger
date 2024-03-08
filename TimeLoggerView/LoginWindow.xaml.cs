using Common.ResponseModels;
using Microsoft.Extensions.DependencyInjection;
using Model.Interface;
using Model.ModelSql;
using Service.Interface;
using Service.Service;
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

        private void PasswordBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                // Perform login action here
                // For example, you might call a method to handle the login process
                // Replace LoginMethod() with your actual login method
                LoginMethod();
                
            }
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginMethod();
            
        }


        private void LoginMethod()
        {
            Response response = _authenticationService.Login(txtUser.Text, txtPass.Password);


            User user = (User)response.Data;



            if (response != null)
            {
                MainDashboardView mainDashboard = new MainDashboardView(user);
                mainDashboard.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect Password or Username");
            }
        }


      

        private void ResetTxt_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
