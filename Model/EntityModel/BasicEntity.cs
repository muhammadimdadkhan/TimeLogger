using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.ModelSql;

namespace Model.EntityModel
{
    public class BasicEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }

        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }


        // Navigation property
        [ForeignKey("CreatedBy")]
        public virtual User CreatedByUser { get; set; }
        [ForeignKey("ModifiedBy")]
        public virtual User ModifiedByUser { get; set; }
    }
}
