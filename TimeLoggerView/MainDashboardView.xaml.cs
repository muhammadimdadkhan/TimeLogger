using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MainDashboardView.xaml
    /// </summary>
    public partial class MainDashboardView : Window
    {
        public MainDashboardView()
        {
            InitializeComponent();
        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();

        }

        private void btn_Home_Click(object sender, RoutedEventArgs e)
        {
            Color customColor = (Color)ColorConverter.ConvertFromString("#383275");
            SolidColorBrush brush = new SolidColorBrush(customColor);
            btnHome.Background = brush;
            btn_User.Background = Brushes.Transparent;
            btn_TimeLogs.Background = Brushes.Transparent;
            btn_Projects.Background = Brushes.Transparent;
            btn_Requests.Background = Brushes.Transparent;
            btn_Audit.Background = Brushes.Transparent;
            btn_Reports.Background = Brushes.Transparent;
        }

        private void btn_User_Click(object sender, RoutedEventArgs e)
        {
            Color customColor = (Color)ColorConverter.ConvertFromString("#383275");
            SolidColorBrush brush = new SolidColorBrush(customColor);
            btn_User.Background = brush;
            btnHome.Background = Brushes.Transparent;
            btn_TimeLogs.Background = Brushes.Transparent;
            btn_Projects.Background = Brushes.Transparent;
            btn_Requests.Background = Brushes.Transparent;
            btn_Audit.Background = Brushes.Transparent;
            btn_Reports.Background = Brushes.Transparent;

        }

        private void btn_TimeLogs_Click(object sender, RoutedEventArgs e)
        {
            Color customColor = (Color)ColorConverter.ConvertFromString("#383275");
            SolidColorBrush brush = new SolidColorBrush(customColor);
            btn_TimeLogs.Background = brush;
            btn_User.Background = Brushes.Transparent;
            btnHome.Background = Brushes.Transparent;
            btn_Projects.Background = Brushes.Transparent;
            btn_Requests.Background = Brushes.Transparent;
            btn_Audit.Background = Brushes.Transparent;
            btn_Reports.Background = Brushes.Transparent;
        }

        private void btn_Projects_Click(object sender, RoutedEventArgs e)
        {

            Color customColor = (Color)ColorConverter.ConvertFromString("#383275");
            SolidColorBrush brush = new SolidColorBrush(customColor);
            btn_Projects.Background = brush;
            btn_User.Background = Brushes.Transparent;
            btn_TimeLogs.Background = Brushes.Transparent;
            btnHome.Background = Brushes.Transparent;
            btn_Requests.Background = Brushes.Transparent;
            btn_Audit.Background = Brushes.Transparent;
            btn_Reports.Background = Brushes.Transparent;
        }

        private void btn_Requests_Click(object sender, RoutedEventArgs e)
        {
            Color customColor = (Color)ColorConverter.ConvertFromString("#383275");
            SolidColorBrush brush = new SolidColorBrush(customColor);
            btn_Requests.Background = brush;
            btn_User.Background = Brushes.Transparent;
            btn_TimeLogs.Background = Brushes.Transparent;
            btn_Projects.Background = Brushes.Transparent;
            btnHome.Background = Brushes.Transparent;
            btn_Audit.Background = Brushes.Transparent;
            btn_Reports.Background = Brushes.Transparent;
        }

        private void btn_Audit_Click(object sender, RoutedEventArgs e)
        {
            Color customColor = (Color)ColorConverter.ConvertFromString("#383275");
            SolidColorBrush brush = new SolidColorBrush(customColor);
            btn_Audit.Background = brush;
            btn_User.Background = Brushes.Transparent;
            btn_TimeLogs.Background = Brushes.Transparent;
            btn_Projects.Background = Brushes.Transparent;
            btn_Requests.Background = Brushes.Transparent;
            btnHome.Background = Brushes.Transparent;
            btn_Reports.Background = Brushes.Transparent;
        }

        private void btn_Reports_Click(object sender, RoutedEventArgs e)
        {
            Color customColor = (Color)ColorConverter.ConvertFromString("#383275");
            SolidColorBrush brush = new SolidColorBrush(customColor);
            btn_Reports.Background = brush;
            btn_User.Background = Brushes.Transparent;
            btn_TimeLogs.Background = Brushes.Transparent;
            btn_Projects.Background = Brushes.Transparent;
            btn_Requests.Background = Brushes.Transparent;
            btn_Audit.Background = Brushes.Transparent;
            btnHome.Background = Brushes.Transparent;
        }
    }
}

    

