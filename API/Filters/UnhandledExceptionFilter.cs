using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Sett.Api.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            new Managers.ExceptionManager().SendReport(context.Exception);

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            response.Content = new StringContent(context.Exception.Message);
            context.Response = response;

            throw new System.Web.Http.HttpResponseException(response);
        }
    }
}