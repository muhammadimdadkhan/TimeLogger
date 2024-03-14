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

        public static Dictionary<MessageType, string> Messages = new Dictionary<MessageType, string>() {
           {MessageType.AddSuccess,"Item added successfully." },
           {MessageType.AddFailure,"Failed to add item." },
           {MessageType.EditSuccess,"Item updated successfully." },
           {MessageType.EditFailure,"Failed to update item." },
           {MessageType.DeleteSuccess,"Item deleted successfully." },
           {MessageType.DeleteFailure,"Failed to delete item." },
           {MessageType.None,"" },
       };
    }
}
