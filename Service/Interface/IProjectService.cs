using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IProjectService
    {
        public List<ProjectsGridVM> GetProjects(int skip, int take);
        public ProjectsGridVM? GetProjectsById(int Id);
    }
}
