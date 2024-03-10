using Model.ModelSql;
using Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeLoggerView.Models;

namespace TimeLoggerView.ViewModels
{
    class UsersVM : ViewModelBase
    {
        private readonly PageModel _pageModel;
      

        public UsersVM()
        {
            _pageModel = new PageModel();
            
        }
    }
}
