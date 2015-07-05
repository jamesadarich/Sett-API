using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sett.API.Controllers
{
    public class DomainController : ApiController
    {
        [HttpGet]
        [Route("domains/current")]
        [Authorize]
        public DataTransferObjects.Domain GetCurrent()
        {
            return new Managers.DomainManager(User.Identity.Name).GetCurrent();
        }
    }
}