using Model.EntityModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ModelSql
{
    public class RolePermission : RoleEntity
    {
        public int RoleID { get; set; }
        public int PermissionID { get; set; }
        public bool View { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool AllData { get; set; }

        // Navigation property
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
        [ForeignKey("PermissionID")]
        public virtual Permission Permission { get; set; }
    }
}
