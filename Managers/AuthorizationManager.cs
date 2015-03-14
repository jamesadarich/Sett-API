using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sett.DataTransferObjects;

namespace Sett.Managers
{
    public class AuthroizationManager : IDisposable
    {
        private Sett.DataAccess.AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthroizationManager()
        {
            _ctx = new Sett.DataAccess.AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public IdentityResult RegisterUser(Sett.DataTransferObjects.Identity userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.Username
            };

            var result = _userManager.Create(user, userModel.Password);

            var settUser = new Models.User();
            settUser.Id = Guid.NewGuid();
            settUser.Username = userModel.Username;
            settUser.FirstName = userModel.FirstName;
            settUser.LastName = userModel.LastName;
            settUser.EmailAddress = userModel.EmailAddress;

            var repo = new DataAccess.Repository();
            repo.Users.Add(settUser);
            var t = repo.SaveChanges();

            return result;
        }

        public IdentityUser FindUser(string userName, string password)
        {
            IdentityUser user = _userManager.Find(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();
        }
    }
}
