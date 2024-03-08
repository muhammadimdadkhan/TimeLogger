using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLoggerView.ViewModels
{
    class DashboardWindowViewModel
    {
        private readonly ITimeLogService _timelogService;

        public DashboardWindowViewModel(ITimeLogService TimelogService)
        {
            _timelogService = TimelogService;
        }
    }
}
