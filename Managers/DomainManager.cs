using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;

namespace Sett.Managers
{
    public class DomainManager
    {
        private Models.Domain _domain;

        public DomainManager(string username)
        {
            _domain = new DataAccess.GenericRepository<Models.Domain>().GetAll().Single(x => x.Users.Any(user => user.Username == username));
        }

        public DataTransferObjects.Domain GetCurrent()
        {
            return _domain.ToDto();
        }

        public DataTransferObjects.Domain Update(DataTransferObjects.Domain domain)
        {
            if (domain.Id != _domain.Id)
            {
                throw new UnauthorizedAccessException();
            }

            var domainRepository = new DataAccess.GenericRepository<Models.Domain>();

            domainRepository.Update(domain.ToModel());

            return domainRepository.GetById(domain.Id).ToDto();
        }
    }
}
