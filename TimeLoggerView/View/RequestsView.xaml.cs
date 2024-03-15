using Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TimeLoggerView.ViewModels;

namespace TimeLoggerView.View
{
    /// <summary>
    /// Interaction logic for RequestsView.xaml
    /// </summary>
    public partial class RequestsView : UserControl
    {
        IRequestService _requestService { get; set; }
        public RequestsView()
        {
            InitializeComponent();

            _requestService = ((App)Application.Current).ServiceProvider.GetService<IRequestService>();
            DataContext = new RequestsVM(_requestService);

            List<RequestGridVM> requests = _requestService.GetRequests(0, 100).ToList();
            RequestsGrid.ItemsSource = requests;
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
