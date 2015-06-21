using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Sett.API.Controllers
{
    public class ArticleController : ApiController
    {
        [HttpGet]
        [Route("{domainUri}/articles")]
        public IEnumerable<DataTransferObjects.Article> GetAllArticles( string domainUri,
                                                                        [FromUri] string where = null,
                                                                        [FromUri] string sort = null,
                                                                        [FromUri] int skip = 0,
                                                                        [FromUri] int take = 10)
        {
            return new Managers.ArticleManager(domainUri).GetAll(where, sort, skip, take);
        }

        [HttpGet]
        [Route("{domainUri}/articles/{articleId}")]
        public DataTransferObjects.Article GetArticle(string domainUri, Guid articleId)
        {
            return new Managers.ArticleManager(domainUri).Get(articleId);
        }

        [HttpDelete]
        [Route("{domainUri}/articles/{articleId}")]
        [Authorize]
        public void DeleteArticle(string domainUri, Guid articleId)
        {
            new Managers.ArticleManager(domainUri).Delete(articleId, User.Identity.Name);
            StatusCode(HttpStatusCode.NoContent);
        }
    }
}
