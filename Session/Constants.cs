using Model.ModelSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session
{
    public static class Constants
    {
        public static List<Role> Roles = new List<Role>() { new Role() { Id = 2, Name = "Planning Engineer" }, new Role() { Id = 3, Name = "User" } };
    }
}
