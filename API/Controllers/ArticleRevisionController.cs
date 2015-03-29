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
        [Route("article/{articleId}/revisions/latest")]
        public DataTransferObjects.ArticleRevision GetLatestRevision(Guid articleId)
        {
            return new Managers.ArticleRevisionManager().GetLatest(articleId);
        }

        [HttpGet]
        [Route("article/{articleId}/revisions")]
        public IEnumerable<DataTransferObjects.ArticleRevision> GetAll(Guid articleId)
        {
            return new Managers.ArticleRevisionManager().GetAll(articleId);
        }

        [HttpPost]
        [Route("article/revision")]
        [Authorize]
        public DataTransferObjects.ArticleRevision PostRevision([FromBody] DataTransferObjects.ArticleRevision revision)
        {
            var username = User.Identity.Name;
            return new Managers.ArticleRevisionManager().CreateArticleRevision(revision, username);
        }
    }
}
