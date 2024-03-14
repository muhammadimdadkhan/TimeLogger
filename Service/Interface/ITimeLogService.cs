using Common.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITimeLogService
    {
        public List<TimeLogsGridVM> GetTimeLogs(int skip, int take);
        public TimeLogsGridVM? GetTimeLogsById(int Id);
    }
}
