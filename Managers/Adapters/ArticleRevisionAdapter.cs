using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett.Managers.Adapters
{
    public static class ArticleRevisionAdapter
    {
        public static DataTransferObjects.ArticleRevision ToDto(this Models.ArticleRevision articleRevision)
        {
            if (articleRevision == null) { return null; }

            var articleRevisionDto = new DataTransferObjects.ArticleRevision();

            articleRevisionDto.Id = articleRevision.Id;
            articleRevisionDto.ArticleId = articleRevision.ArticleId;
            articleRevisionDto.Author = articleRevision.Author.ToDto();
            articleRevisionDto.Content = articleRevision.Content;
            articleRevisionDto.FeaturedImageUrl = articleRevision.FeaturedImageUrl;
            articleRevisionDto.Summary = articleRevision.Summary;
            articleRevisionDto.Timestamp = articleRevision.Timestamp;
            articleRevisionDto.Title = articleRevision.Title;

            return articleRevisionDto;
        }

        public static Models.ArticleRevision ToModel(this DataTransferObjects.ArticleRevision articleRevision, DataAccess.Repository repository)
        {
            if (articleRevision == null) { return null; }

            var articleRevisionModel = new Models.ArticleRevision();
            articleRevisionModel.Id = Guid.NewGuid();

            if (articleRevision.Id != new Guid())
            {
                articleRevisionModel = repository.ArticleRevisions.Where(b => b.Id == articleRevision.Id).Single();
            }
            articleRevisionModel.ArticleId = articleRevision.ArticleId;
            articleRevisionModel.Author = articleRevision.Author.ToModel(repository);
            if (articleRevisionModel.Author != null)
            {
                articleRevisionModel.AuthorId = articleRevisionModel.Author.Id;
            }
            articleRevisionModel.Content = articleRevision.Content;
            articleRevisionModel.FeaturedImageUrl = articleRevision.FeaturedImageUrl;
            articleRevisionModel.Summary = articleRevision.Summary;
            articleRevisionModel.Timestamp = articleRevision.Timestamp;
            articleRevisionModel.Title = articleRevision.Title;

            return articleRevisionModel;
        }
    }
}
