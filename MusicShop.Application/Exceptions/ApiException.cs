using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MusicShop.Application.Exceptions
{
    public class ApiException:Exception
    { 
        public string UserMessage { get; set; }
        public string LogMessage { get; set; }
        public HttpStatusCode StatusCode { get; set; }

        public ApiException(string logMessage,HttpStatusCode httpStatusCode)
        {
            LogMessage = logMessage;
            StatusCode = httpStatusCode;
        }
    }
}
