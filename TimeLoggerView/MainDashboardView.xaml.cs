using Common.ResponseModels;
using Microsoft.Extensions.DependencyInjection;
using Model.ModelSql;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for MainDashboardView.xaml
    /// </summary>
    public partial class MainDashboardView : Window
    {

        //public string TotalHours { get; set; }

        public string TotalHoursFirstIteration { get; set; }
        public string TotalHoursSecondIteration { get; set; }
        public string TotalHoursThirdIteration { get; set; }
        public string TotalHoursFourthIteration { get; set; }
        public string TotalHoursFifthIteration { get; set; }
        public string TotalHoursSixthIteration { get; set; }
        public string TotalHoursSeventhIteration { get; set; }

        ITimeLogService _TimeLogService { get; set; }
        public MainDashboardView(User user)
        {
            
            




            InitializeComponent();
            // Resolve the service from App's ServiceProvider
            _TimeLogService = ((App)Application.Current).ServiceProvider.GetService<ITimeLogService>();

            // Initialize the ViewModel with the service
            DataContext = new DashboardWindowViewModel(_TimeLogService);


            List<TimeLog> response =  _TimeLogService.GetTimeLogs(user,7);
            int iteration = 0;

            foreach (TimeLog timeLog in response)
            {
                DateTime? startTimeNullable = timeLog.StartTime; // Nullable DateTime object representing start time
                DateTime? endTimeNullable = timeLog.EndTime; // Nullable DateTime object representing end time

                // Check if both start and end times are not null before subtracting
                if (startTimeNullable != null && endTimeNullable != null)
                {
                    DateTime startTime = startTimeNullable.Value; // Extract the value from the nullable DateTime
                    DateTime endTime = endTimeNullable.Value; // Extract the value from the nullable DateTime

                    // Calculate the difference
                    TimeSpan difference = endTime - startTime;

                    // Now you can use the properties of the TimeSpan object, such as TotalHours, TotalMinutes, TotalSeconds, etc.
                    //double totalHours = difference.TotalHours;
                    double totalMinutes = difference.TotalMinutes;
                    double totalSeconds = difference.TotalSeconds;



                    //TotalHours = difference.TotalHours.ToString()+" Hours";


                    string totalHours = difference.TotalHours.ToString() + " Hours";

                    // Set the TotalHours property for the corresponding iteration
                    if (iteration == 0)
                    {
                        TotalHoursFirstIteration = totalHours;
                    }
                    else if (iteration == 1)
                    {
                        TotalHoursSecondIteration = totalHours;
                        
                    }
                    else if (iteration == 2)
                    {
                        TotalHoursThirdIteration = totalHours;

                    }
                    else if (iteration == 3)
                    {
                        TotalHoursFourthIteration = totalHours;

                    }
                    else if (iteration == 4)
                    {
                        TotalHoursFifthIteration = totalHours;

                    }
                    else if (iteration == 5)
                    {
                        TotalHoursSixthIteration = totalHours;

                    }
                    else if (iteration == 6)
                    {
                        TotalHoursSeventhIteration = totalHours;

                    }
                    iteration++; // Increment the iteration counter






                }
                else
                {
                    // Handle the case where either start or end time is null
                    // For example, throw an exception, log an error, or handle it gracefully based on your application's requirements
                }




                //Console.WriteLine($"StartTime: {timeLog.StartTime}, EndTime: {timeLog.EndTime}");

            }
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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

    

