using Common.ViewModels;
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
    public class UserService:IUserService
    {
        IRepository _repository;
        public UserService(IRepository repository)
        {
                _repository = repository;
        }
        public List<UserGridVM> GetUsers(int skip, int take)
        { 
            List<UserGridVM> response = _repository.GetQueryableWithOutTracking<User>()
                .OrderByDescending(x=>x.Modified)
                .Skip(skip)
                .Take(take)
                .Select(x=> new UserGridVM()
                {
                    Name= x.FirstName+x.LastName,
                    Username=x.Username,
                    Designation=x.Designation,
                    Email=x.Email,
                    Role=x.Role.Name
                })
                .ToList();
            return response;
        }

        public UserGridVM? GetUserById(int Id)
        {
            UserGridVM? response = _repository.GetQueryableWithOutTracking<User>()
                .Where(x=>x.Id.Equals(Id))
                .Select(x => new UserGridVM()
                {
                    Name = x.FirstName + x.LastName,
                    Username = x.Username,
                    Designation = x.Designation,
                    Email = x.Email,
                    Role = x.Role.Name
                })
                .FirstOrDefault();
            return response;
        }

        public bool AddUser(User user)
        {
            _repository.InsertModel(user);
            return _repository.Save()>0;
        }

        public List<DropdownModel> GetRolesForDropdown()
        {
          return  _repository.GetQueryableWithOutTracking<Role>().Where(x=>x.IsActive.Equals(true))
                .Select(x=>new DropdownModel
                {
                    Id=x.Id,
                    Name=x.Name,
                }).ToList();
        }
    }
}
