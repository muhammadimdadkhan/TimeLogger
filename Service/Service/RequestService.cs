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
    public class RequestService:IRequestService
    {
        IRepository _repository;
        public RequestService(IRepository repository)
        {
            _repository = repository;
        }

        public List<RequestGridVM> GetRequests(int skip, int take)
        {
            List<RequestGridVM> response = _repository.GetQueryableWithOutTracking<Request>()
                .OrderByDescending(x => x.Modified)
                .Skip(skip)
                .Take(take)
                .Select(x => new RequestGridVM()
                {
                    UserName = x.User != null ? x.User.Username : null,
                    PlanningEngName = x.PlanningEngineer != null ? x.PlanningEngineer.Username : null,
                    ProjectName = x.Project != null ? x.Project.ProjectName : null,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Timestamp = x.Timestamp,
                    RequestStatus = x.RequestStatus,

                })
                .ToList();
            return response;
        }

        public RequestGridVM? GetRequestsById(int Id)
        {
            RequestGridVM? response = _repository.GetQueryableWithOutTracking<Request>()
                .Where(x => x.Id.Equals(Id))
                .Select(x => new RequestGridVM()
                {
                    UserName = x.User != null ? x.User.Username : null,
                    PlanningEngName = x.PlanningEngineer != null ? x.PlanningEngineer.Username : null,
                    ProjectName = x.Project != null ? x.Project.ProjectName : null,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    Timestamp = x.Timestamp,
                    RequestStatus = x.RequestStatus,

                })
                .FirstOrDefault();
            return response;
        }

        
        
    }
}
