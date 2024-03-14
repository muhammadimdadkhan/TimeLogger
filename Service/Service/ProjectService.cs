using Common.ViewModels;
using Model.Interface;
using Model.ModelSql;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class ProjectService:IProjectService
    {
        

        IRepository _repository;
        public ProjectService(IRepository repository)
        {
            _repository = repository;
        }

        public List<ProjectsGridVM> GetProjects(int skip, int take)
        {
            List<ProjectsGridVM> response = _repository.GetQueryableWithOutTracking<Project>()
                .OrderByDescending(x => x.Modified)
                .Skip(skip)
                .Take(take)
                .Select(x => new ProjectsGridVM()
                {
                    ProjectId = x.Id,
                    ProjectName = x.ProjectName,
                    Description = x.Description,
                    CreatedBy = x.CreatedBy
                })
                .ToList();
            return response;
        }

        public ProjectsGridVM? GetProjectsById(int Id)
        {
            ProjectsGridVM? response = _repository.GetQueryableWithOutTracking<Project>()
                .Where(x => x.Id.Equals(Id))
                .Select(x => new ProjectsGridVM()
                {
                    ProjectId = x.Id,
                    ProjectName = x.ProjectName,
                    Description = x.Description,
                    CreatedBy = x.CreatedBy
                })
                .FirstOrDefault();
            return response;
        }
    }
}
