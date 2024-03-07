using Common.ResponseModels;
using Model.ModelSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITimeLogService
    {
       public List<TimeLog> GetTimeLogs(User user ,int take);
    }
}
