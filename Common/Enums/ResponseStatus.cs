using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
     public enum ResponseStatus
    {
        None = 0,
        Success = 200,
        Failed = 400,
        AuthenticationFailed = 403,
        InternalError = 500
    }
}
