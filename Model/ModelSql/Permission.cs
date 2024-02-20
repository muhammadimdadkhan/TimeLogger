using Model.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelSql
{
    public class Permission : RoleEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        //public bool Add { get; set; }
        //public bool Update { get; set; }
        //public bool Delete { get; set; }
        //public bool View { get; set; }
    
    }
}
