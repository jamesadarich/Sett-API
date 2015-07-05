using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace Sett.API.Controllers
{
    public class SitemapController : ApiController
    {
        [HttpGet]
        [Route("{domainName}/sitemap")]
        public/* IHttpActionResult*/ DataTransferObjects.Sitemap GetSitemap(string domainName)
        {
            /*
            var manager = ;
            return Content(HttpStatusCode.OK, new DataTransferObjects.Sitemap(), Configuration.Formatters.XmlFormatter); 
             * */
            var sitemap = new DataTransferObjects.Sitemap();
            sitemap.AddItem("");
            return new Managers.SitemapManager(domainName).GetSitemap();

            //return Content(HttpStatusCode.OK, sitemap, Configuration.Formatters.XmlFormatter); 
        }
    }
}