using Common.ResponseModels;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        Response IAuthenticationService.Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
