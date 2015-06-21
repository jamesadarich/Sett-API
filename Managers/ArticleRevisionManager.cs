using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;

namespace Sett.Managers
{
    public class ArticleRevisionManager
    {
        private Models.Domain _domain;
        private IQueryable<Models.ArticleRevision> _domainArticleRevisions;

        public ArticleRevisionManager(string domainUri)
        {
            _domain = new DataAccess.GenericRepository<Models.Domain>().GetAll().Single(x => x.Uri == domainUri);
            _domainArticleRevisions = new DataAccess.GenericRepository<Models.ArticleRevision>()
                                                .GetAll()
                                                .Where(revision => revision.Author.DomainId == _domain.Id);
        }

        public DataTransferObjects.ArticleRevision GetLatest(Guid articleId)
        {
            return _domainArticleRevisions
                        .Where(ar => ar.ArticleId == articleId)
                        .OrderByDescending(ar => ar.Timestamp)
                        .First().ToDto();
        }

        public IEnumerable<DataTransferObjects.ArticleRevision> GetAll(Guid articleId)
        {
            return _domainArticleRevisions
                        .Where(ar => ar.ArticleId == articleId)
                        .OrderByDescending(ar => ar.Timestamp)
                        .ToList()
                        .Select(ar => ar.ToDto());
        }

        public DataTransferObjects.ArticleRevision CreateArticleRevision(DataTransferObjects.ArticleRevision revision, string username)
        {
            var repository = new DataAccess.Repository();

            var revisionModel = revision.ToModel(repository);
            revisionModel.Author = repository.Users.Single(u => u.Username == username);
            revisionModel.AuthorId = revisionModel.Author.Id;

            revisionModel.Timestamp = DateTime.UtcNow;

            if (revisionModel.ArticleId == new Guid())
            {
                var article = new Models.Article();
                article.Id = Guid.NewGuid();
                var regex = new System.Text.RegularExpressions.Regex(@"[^a-zA-Z0-9 \-]");
                article.Slug = regex.Replace(revisionModel.Title.Replace(" ", "-"), "");
                article.ArticleRevisions.Add(revisionModel);
                revisionModel.ArticleId = article.Id;
                revisionModel.Article = article;

                repository.Articles.Add(article);
                repository.SaveChanges();
                return revisionModel.ToDto();
            }

            repository.ArticleRevisions.Add(revisionModel);
            repository.SaveChanges();

            return revisionModel.ToDto();
        }
    }
}
