using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;
using Sett.DataAccess.Extensions;

namespace Sett.Managers
{
    public class ArticleManager
    {
        private Models.Domain _domain;
        private IQueryable<Models.Article> _domainArticles;

        public ArticleManager(string domainUri)
        {
            _domain = new DataAccess.GenericRepository<Models.Domain>().GetAll().Single(x => x.Uri == domainUri);
            _domainArticles = new DataAccess.GenericRepository<Models.Article>()
                                    .GetAll()
                                    .Where(article => article.ArticleRevisions.Any(revision => revision.Author.DomainId == _domain.Id));
        }

        public IEnumerable<DataTransferObjects.Article> GetAll(string where, string sort, int skip, int take)
        {
            var t = new Models.Article();

            return _domainArticles
                        .Filter(where)
                        .Sort(sort)
                        .Skip(skip)
                        .Take(take)
                        .ToList()
                        .Select(a => a.ToDto());
        }

        public DataTransferObjects.Article Get(Guid articleId)
        {
            return _domainArticles
                        .Where(a => a.Id == articleId)
                        .ToList().Single().ToDto();
        }

        public void Delete(Guid articleId, string username)
        {
            var repository =  new DataAccess.Repository();
            var user = repository.Users.Single(u => u.Username == username);
            var revisions = repository.ArticleRevisions.Where(a => a.ArticleId == articleId);
            var article = _domainArticles.Single(a => a.Id == articleId);

            repository.ArticleRevisions.RemoveRange(revisions);
            repository.Articles.Remove(article);
            repository.SaveChanges();
        }
    }
}
