using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Sett.Api.Filters;

namespace Sett.Api
{
    public class AccountController : ApiController
    {
        private Managers.AuthroizationManager _repo = null;

        public AccountController()
        {
            _repo = new Managers.AuthroizationManager();
        }

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody] Sett.DataTransferObjects.Identity userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = _repo.RegisterUser(userModel);

            if (!result.Succeeded)
            {
                return InternalServerError();
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}