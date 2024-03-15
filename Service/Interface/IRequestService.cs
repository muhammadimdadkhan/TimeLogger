using Common.ViewModels;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRequestService
    {
        public List<RequestGridVM> GetRequests(int skip, int take);
        public RequestGridVM? GetRequestsById(int Id);
    }
}
