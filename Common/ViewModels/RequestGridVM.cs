using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class RequestGridVM
    {
        
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int? PlanningEngineerID { get; set; }
        public string PlanningEngName { get; set; }
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime Timestamp { get; set; }
        public RequestStatus RequestStatus { get; set; }
    }
}
