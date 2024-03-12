using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeLoggerView.Models;

namespace TimeLoggerView.ViewModels
{
    class TimeLogsVM : ViewModelBase
    {
        
        private readonly PageModel _pageModel;

        public readonly ITimeLogService _timeLogService;

        public TimeLogsVM(ITimeLogService timeLogService)
        {
            _timeLogService = timeLogService;
            _pageModel = new PageModel();

        }
        public TimeLogsVM()
        {

            _timeLogService = ((App)Application.Current).ServiceProvider.GetService<ITimeLogService>();
            _pageModel = new PageModel();
        }
    }
}
