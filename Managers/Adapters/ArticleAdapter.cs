using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett.Managers.Adapters
{
    public static class ArticleAdapter
    {
        public static DataTransferObjects.Article ToDto(this Models.Article article)
        {
            if (article == null) { return null; }

            var articleDto = new DataTransferObjects.Article();
            articleDto.Id = article.Id;

            articleDto.Slug = article.Slug;

            var firstRevision = article.ArticleRevisions.OrderBy(ar => ar.Timestamp).First();

            articleDto.Author = firstRevision.Author.ToDto();
            articleDto.Timestamp = firstRevision.Timestamp;

            var latestRevision = article.ArticleRevisions.OrderByDescending(ar => ar.Timestamp).First();

            articleDto.Content = latestRevision.Content;
            articleDto.FeaturedImageUrl = latestRevision.FeaturedImageUrl;
            articleDto.Summary = latestRevision.Summary;
            articleDto.Title = latestRevision.Title;

            return articleDto;
        }
    }
}
