using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Messages
{
    public static class ResponseMessage
    {
       public static Dictionary<ResponseStatus, string> DefaultMessage = new Dictionary<ResponseStatus, string>() {
           {ResponseStatus.InternalError,"An error occured." },
           {ResponseStatus.Failed,"Unable to process request." },
           {ResponseStatus.Success,"Success." },
           {ResponseStatus.AuthenticationFailed,"Invalid username or password." },
           {ResponseStatus.None,"" },
       };


    }
}
