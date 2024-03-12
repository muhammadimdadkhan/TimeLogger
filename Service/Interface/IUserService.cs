using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        public List<UserGridVM> GetUsers(int skip, int take);
        public UserGridVM? GetUserById(int Id);
    }
}
