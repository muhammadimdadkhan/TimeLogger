using Common.Enums;
using Common.ResponseModels;
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
    public class TimeLogService : ITimeLogService
    {
        private readonly IRepository _iRepository;
        public TimeLogService(
            IRepository repository
            )
        {
            _iRepository = repository;
        }

        public List<TimeLog> GetTimeLogs(User user, int take)
        {
           List<TimeLog> timelog = _iRepository.GetQueryableWithOutTracking<TimeLog>().Where(x => x.UserID.Equals(user.Id)).OrderBy(x => x.StartTime).Take(take).ToList();
            /* ResponseListData response = new ResponseListData()
             {
                 Data = timelog,
                 Message = "Success",
                 Status = ResponseStatus.Success


             };
             return response;*/
            return timelog;
        }


        
    }
}

