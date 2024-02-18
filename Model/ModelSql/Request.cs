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
    // Request entity model
    public class Request : BasicEntity
    {
        public int UserID { get; set; }
        public int? PlanningEngineerID { get; set; }
        public int ProjectID { get; set; }
        public int? TimeLogID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public List<string> Comments { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation properties
        [ForeignKey("UserID")]
        public virtual User User { get; set; }

        [ForeignKey("PlanningEngineerID")]
        public virtual User PlanningEngineer { get; set; }

        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }
        [ForeignKey("TimeLogID")]
        public virtual TimeLog TimeLog { get; set; }
    }
}
