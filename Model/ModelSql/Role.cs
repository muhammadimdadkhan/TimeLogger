using Model.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelSql
{
    // Role entity model
    public class Role : BasicEntity
    {
        public string Name { get; set; }

        // Navigation property
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
    }
}
