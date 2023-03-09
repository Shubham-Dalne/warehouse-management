using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;



namespace WareHouseManagement.CustomException
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message ;
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
            }
            if (exceptionMessage == null)
                exceptionMessage = "An unhandled exception was thrown by service. ";
               
                var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
              {
                
                 Content = new StringContent(exceptionMessage),
                    ReasonPhrase = "Internal Server Error. Please Contact your Administrator."
                   
            };
            
            actionExecutedContext.Response = response;
        }
    }
}