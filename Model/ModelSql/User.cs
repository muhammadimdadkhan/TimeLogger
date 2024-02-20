using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityModel;

namespace Model.ModelSql
{

    // User entity model
    public class User: BasicEntity
    {
        public int RoleID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Designation { get; set; }
        public string Email { get; set; }

        // Navigation property
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
    }
}
