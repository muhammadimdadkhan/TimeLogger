using Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
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
    /// Interaction logic for TimeLogsView.xaml
    /// </summary>
    public partial class TimeLogsView : UserControl
    {
        ITimeLogService _timeLogService { get; set; }

        public TimeLogsView()
        {
            InitializeComponent();
            _timeLogService = ((App)Application.Current).ServiceProvider.GetService<ITimeLogService>();

            DataContext = new TimeLogsVM(_timeLogService);

            List<TimeLogsGridVM> timelogs = _timeLogService.GetTimeLogs(0,100).ToList();
            TimeLogsGrid.ItemsSource = timelogs;
            

            


        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {

        }

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
