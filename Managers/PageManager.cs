using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;

namespace Sett.Managers
{
    public class PageManager
    {
        
        private Models.Domain _domain;
        private IQueryable<Models.Page> _pages;
        private DataAccess.GenericRepository<Models.Page> _pageRepository;

        public PageManager(string domainName, string username)
        {
            _domain = new DataAccess.GenericRepository<Models.Domain>().GetAll().Single(x => x.Name == domainName);
            _pages = new DataAccess.GenericRepository<Models.Page>()
                                                .GetAll()
                                                .Where(page => page.DomainId == _domain.Id);
            _pageRepository = new DataAccess.GenericRepository<Models.Page>();
        }

        public IEnumerable<DataTransferObjects.Page> GetAll()
        {
            return _pageRepository.GetAll().ToList().Select(page => page.ToDto());
        }

        public DataTransferObjects.Page GetById(Guid pageId)
        {
            return _pageRepository.GetById(pageId).ToDto();
        }

        public DataTransferObjects.Page Create(DataTransferObjects.Page page)
        {
            page.Id = Guid.NewGuid();
            page.Domain = _domain.ToDto();
            _pageRepository.Add(page.ToModel());
            return _pageRepository.GetById(page.Id).ToDto();
        }

        public DataTransferObjects.Page Update(DataTransferObjects.Page page)
        {
            _pageRepository.Update(page.ToModel());
            return _pageRepository.GetById(page.Id).ToDto();
        }

        public void Delete(Guid pageId)
        {
            _pageRepository.Remove(_pageRepository.GetById(pageId));
        }
    }
}
