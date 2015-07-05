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
        [Route("{domainName}/article/{articleId}/revisions/latest")]
        public DataTransferObjects.ArticleRevision GetLatestRevision(string domainName, Guid articleId)
        {
            return new Managers.ArticleRevisionManager(domainName).GetLatest(articleId);
        }

        [HttpGet]
        [Route("{domainName}/article/{articleId}/revisions")]
        public IEnumerable<DataTransferObjects.ArticleRevision> GetAll(string domainName, Guid articleId)
        {
            return new Managers.ArticleRevisionManager(domainName).GetAll(articleId);
        }

        [HttpPost]
        [Route("{domainName}/article/revision")]
        [Authorize]
        public DataTransferObjects.ArticleRevision PostRevision(string domainName, [FromBody] DataTransferObjects.ArticleRevision revision)
        {
            var username = User.Identity.Name;
            return new Managers.ArticleRevisionManager(domainName).CreateArticleRevision(revision, username);
        }
    }
}
