using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ResponseModels
{
    public class Response
    {
        public string Message { get; set; }
        public ResponseStatus Status { get; set; }
        public List<object> Data { get; set; }
    }
}
