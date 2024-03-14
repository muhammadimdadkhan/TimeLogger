using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModels
{
    public class ProjectsGridVM
    {
        public int ProjectId {  get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int? CreatedBy { get; set; }
        
    }
}
