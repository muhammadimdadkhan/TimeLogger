using Microsoft.Extensions.DependencyInjection;
using Model.ModelSql;
using Service.Interface;
using Service.Service;
using Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TimeLoggerView.Models;

namespace TimeLoggerView.ViewModels
{
    class UsersVM : ViewModelBase
    {
        private readonly PageModel _pageModel;

        public readonly IUserService _userService;

        public UsersVM(IUserService userService)
        {
            _userService = userService;
            _pageModel = new PageModel();

        }
        public UsersVM()
        {

            _userService = ((App)Application.Current).ServiceProvider.GetService<IUserService>();
            _pageModel = new PageModel();
        }

    }
}
