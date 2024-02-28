using Common.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IAuthenticationService
    {
        public Response Login(string username, string password);
    }
}
