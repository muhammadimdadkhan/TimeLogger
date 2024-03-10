using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLoggerView.Models;

namespace TimeLoggerView.ViewModels
{
    class RequestsVM : ViewModelBase
    {
        private readonly PageModel _pageModel;


        public RequestsVM()
        {
            _pageModel = new PageModel();

        }
    }
}
