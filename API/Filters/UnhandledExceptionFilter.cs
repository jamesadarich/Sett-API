using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Sett.API.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            response.Content = new StringContent(context.Exception.Message);
            context.Response = response;

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("you@yourcompany.com", "user@hotmail.com");
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.google.com";
            mail.Subject = "Sett API Error";
            mail.Body = context.Exception.Message;
            client.Send(mail);
        }
    }
}