using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;

namespace Sett.Managers
{
    public class UserManager
    {
        private Models.Domain _domain;
        private IQueryable<Models.User> _domainUsers;

        public UserManager(string domainName)
        {
            _domain = new DataAccess.GenericRepository<Models.Domain>().GetAll().Single(x => x.Name == domainName);
            _domainUsers = new DataAccess.GenericRepository<Models.User>()
                                    .GetAll()
                                    .Where(user => user.DomainId == _domain.Id);
        }

        public DataTransferObjects.User GetByUsername(string username)
        {
            return new DataAccess.Repository().Users.Single(u => u.Username == username).ToDto();
        }
    }
}
