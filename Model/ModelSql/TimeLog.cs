using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Model.EntityModel;

namespace Model.ModelSql
{
    // TimeLog entity model
    public class TimeLog: BasicEntity
    {
        public int UserID { get; set; }
        public int ProjectID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public TimeLogStatus? TimeLogStatus { get; set; }
        public string? Comment { get; set; }

        // Navigation properties
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
    }
}
