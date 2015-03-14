using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;

namespace Sett.Managers
{
    public class ExceptionManager
    {
        public void SendReport(Exception exception)
        {
            var request = System.Net.HttpWebRequest.CreateHttp("http://api.imaginarium.getsett.net/error-reaper/report/dot-net");
            request.Method = "POST";
            request.ContentType = "application/json";
            using (var streamWriter = new System.IO.StreamWriter(request.GetRequestStream()))
            {
                var reportDto = exception.ToReport();

                var reportJson = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(reportDto);
                streamWriter.Write(reportJson);
            }

            try
            {
                var httpResponse = (System.Net.HttpWebResponse)request.GetResponse();
                using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream()))
                {
                    var responseText = streamReader.ReadToEnd();
                    //Now you have your response.
                    //or false depending on information in the response
                }
            }
            catch (System.Net.WebException e)
            {
                Console.Out.Write(e.Message);
            }
        }
    }
}
