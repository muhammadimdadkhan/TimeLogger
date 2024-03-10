using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TimeLoggerView.ViewModels
{
    class NavigationVM : ViewModelBase
    {
        IUserService _userService;

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand UserCommand { get; set; }
        public ICommand TimeLogCommand { get; set; }
        public ICommand ProjectCommand { get; set; }
        public ICommand RequestCommand { get; set; }

        private void User(object obj) => CurrentView = new UsersVM(_userService);
        private void TimeLog(object obj) => CurrentView = new TimeLogsVM();
        private void Project(object obj) => CurrentView = new ProjectsVM();
        private void Request(object obj) => CurrentView = new RequestsVM();

        public NavigationVM()
        {
            _userService = ((App)Application.Current).ServiceProvider.GetService<IUserService>();

            UserCommand = new RelayCommand(User);
            TimeLogCommand = new RelayCommand(TimeLog);
            ProjectCommand = new RelayCommand(Project);
            RequestCommand = new RelayCommand(Request);

            // Startup Page
            CurrentView = new UsersVM(_userService);
        }
    }
}
