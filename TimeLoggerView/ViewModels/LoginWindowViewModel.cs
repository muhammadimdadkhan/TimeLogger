using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeLoggerView.ViewModels
{
    class LoginWindowViewModel
    {
        private readonly IAuthenticationService _authenticationService;

        public LoginWindowViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

    }
}
