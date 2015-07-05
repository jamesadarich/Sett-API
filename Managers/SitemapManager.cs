using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Sett.Managers
{
    public class SitemapManager
    {
        private Models.Domain _domain;
        private IQueryable<Models.Article> _domainArticles;
        private IQueryable<Models.Page> _domainPages;

        public SitemapManager(string domainName)
        {
            _domain = new DataAccess.GenericRepository<Models.Domain>().GetAll().Single(x => x.Name == domainName);
            _domainArticles = new DataAccess.GenericRepository<Models.Article>()
                                    .GetAll()
                                    .Where(article => article.ArticleRevisions.Any(revision => revision.Author.DomainId == _domain.Id));
            _domainPages = new DataAccess.GenericRepository<Models.Page>()
                                    .GetAll()
                                    .Where(page => page.DomainId == _domain.Id);

        }

        public DataTransferObjects.Sitemap GetSitemap()
        {
            var sitemap = new DataTransferObjects.Sitemap();

            foreach (var page in _domainPages)
            {
                sitemap.AddItem(_domain.Uri + _domain.PageBaseUri + page.Uri);
            }

            foreach(var article in _domainArticles) {
                sitemap.AddItem(_domain.Uri + _domain.ArticleBaseUri + article.Slug);
            }

            return sitemap;
        }
    }
}
