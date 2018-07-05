using ContactManagementDAL.Implementation;
using ContactManagementDAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ContactManagementAPI.Filters
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        readonly ILogger _logger;
        public CustomExceptionAttribute()
        {
            _logger = new Logger();
        }
        public override void OnException(HttpActionExecutedContext context)
        {
            string exceptionMessage = string.Empty;
            if (context.Exception.InnerException == null)
            {
                exceptionMessage = context.Exception.Message;
            }
            else
            {
                exceptionMessage = context.Exception.InnerException.Message;
            }
            _logger.Log(exceptionMessage);
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),  
                    ReasonPhrase = "Internal Server Error.Please Contact your Administrator."
            };
            context.Response = response;
        }
    }
}