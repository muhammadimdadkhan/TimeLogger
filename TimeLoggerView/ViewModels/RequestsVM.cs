using Microsoft.Extensions.DependencyInjection;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeLoggerView.Models;

namespace TimeLoggerView.ViewModels
{
    class RequestsVM : ViewModelBase
    {
        private readonly PageModel _pageModel;

        public readonly IRequestService _RequestService;

        public RequestsVM(IRequestService RequestService)
        {
            _RequestService = RequestService;
            _pageModel = new PageModel();

        }
        public RequestsVM()
        {

            _RequestService = ((App)Application.Current).ServiceProvider.GetService<IRequestService>();
            _pageModel = new PageModel();
        }
    }
}
