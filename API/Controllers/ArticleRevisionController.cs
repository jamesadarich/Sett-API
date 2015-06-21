using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sett.Api.Controllers
{
    public class ArticleRevisionController : ApiController
    {
        [HttpGet]
        [Route("{domainUri}/article/{articleId}/revisions/latest")]
        public DataTransferObjects.ArticleRevision GetLatestRevision(string domainUri, Guid articleId)
        {
            return new Managers.ArticleRevisionManager(domainUri).GetLatest(articleId);
        }

        [HttpGet]
        [Route("{domainUri}/article/{articleId}/revisions")]
        public IEnumerable<DataTransferObjects.ArticleRevision> GetAll(string domainUri, Guid articleId)
        {
            return new Managers.ArticleRevisionManager(domainUri).GetAll(articleId);
        }

        [HttpPost]
        [Route("{domainUri}/article/revision")]
        [Authorize]
        public DataTransferObjects.ArticleRevision PostRevision(string domainUri, [FromBody] DataTransferObjects.ArticleRevision revision)
        {
            var username = User.Identity.Name;
            return new Managers.ArticleRevisionManager(domainUri).CreateArticleRevision(revision, username);
        }
    }
}
