using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sett.API.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("{domainName}/users/current")]
        [Authorize]
        public DataTransferObjects.User GetCurrentUser(string domainName)
        {
            return new Managers.UserManager(domainName).GetByUsername(User.Identity.Name);
        }
    }
}
