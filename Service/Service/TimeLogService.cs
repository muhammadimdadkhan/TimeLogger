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
    public class TimeLogService:ITimeLogService
    {
        IRepository _repository;
        public TimeLogService(IRepository repository)
        {
            _repository = repository;
        }
        

        public List<TimeLogsGridVM> GetTimeLogs(int skip, int take)
        {
            List<TimeLogsGridVM> response = _repository.GetQueryableWithOutTracking<TimeLog>()
                .OrderByDescending(x => x.Modified)
                .Skip(skip)
                .Take(take)
                .Select(x => new TimeLogsGridVM()
                {
                    UserId = x.UserID,
                    ProjectId = x.ProjectID,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                    
                })
                .ToList();
            return response;
        }

        public TimeLogsGridVM? GetTimeLogsById(int Id)
        {
            TimeLogsGridVM? response = _repository.GetQueryableWithOutTracking<TimeLog>()
                .Where(x => x.UserID.Equals(Id))
                .Select(x => new TimeLogsGridVM()
                {
                    UserId = x.UserID,
                    ProjectId = x.ProjectID,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime
                })
                .FirstOrDefault();
            return response;
        }
    }
}
