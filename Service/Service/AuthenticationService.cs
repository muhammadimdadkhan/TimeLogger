using Common.Enums;
using Common.Messages;
using Common.ResponseModels;
using Model.Interface;
using Model.ModelSql;
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
        private readonly IRepository _iRepository;
        public AuthenticationService(
            IRepository repository
            )
        {
            _iRepository = repository;
        }
        Response IAuthenticationService.Login(string username, string password)
        {
            Response response = null;

            User user = _iRepository.GetQueryableWithOutTracking<User>().Where(x => x.Username.Equals(username) && x.Password.Equals(password)).FirstOrDefault();
            if (user != null)
            {
                response = new Response()
                {
                    Data = user,
                    Message = ResponseMessage.DefaultMessage[ResponseStatus.Success],
                    Status = ResponseStatus.Success
                };
            }
            else
            {
                response = new Response()
                {
                    Message = ResponseMessage.DefaultMessage[ResponseStatus.AuthenticationFailed],
                    Status = ResponseStatus.AuthenticationFailed
                };
            }
            return response;
        }
    }
}
