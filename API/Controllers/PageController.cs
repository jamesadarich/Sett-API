using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sett.API.Controllers
{
    public class PageController : ApiController
    {
        [HttpGet]
        [Route("{domainName}/pages")]
        public IEnumerable<DataTransferObjects.Page> GetAll(string domainName)
        {
            return new Managers.PageManager(domainName, User.Identity.Name).GetAll();
        }

        [HttpGet]
        [Route("{domainName}/page/{pageId}")]
        [Authorize]
        public DataTransferObjects.Page Get(string domainName, Guid pageId)
        {
            return new Managers.PageManager(domainName, User.Identity.Name).GetById(pageId);
        }

        [HttpPost]
        [Route("{domainName}/page")]
        [Authorize]
        public DataTransferObjects.Page Post(string domainName, [FromBody] DataTransferObjects.Page page)
        {
            return new Managers.PageManager(domainName, User.Identity.Name).Create(page);
        }

        [HttpPut]
        [Route("{domainName}/page")]
        [Authorize]
        public DataTransferObjects.Page Put(string domainName, [FromBody] DataTransferObjects.Page page)
        {
            return new Managers.PageManager(domainName, User.Identity.Name).Update(page);
        }

        [HttpDelete]
        [Route("{domainName}/page/{pageId}")]
        [Authorize]
        public void Delete(string domainName, Guid pageId)
        {
            new Managers.PageManager(domainName, User.Identity.Name).Delete(pageId);
            StatusCode(HttpStatusCode.NoContent);
        }
    }
}