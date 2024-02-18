using Model.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelSql
{
    public class RolePermission : BasicEntity
    {
        public int RoleID { get; set; }
        public int PermissionID { get; set; }

        // Navigation property
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
        [ForeignKey("PermissionID")]
        public virtual Permission Permission { get; set; }
    }
}
