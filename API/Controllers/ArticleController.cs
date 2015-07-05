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
        [Route("{domainName}/articles")]
        public IEnumerable<DataTransferObjects.Article> GetAllArticles(string domainName,
                                                                        [FromUri] string where = null,
                                                                        [FromUri] string sort = null,
                                                                        [FromUri] int skip = 0,
                                                                        [FromUri] int take = 10)
        {
            return new Managers.ArticleManager(domainName).GetAll(where, sort, skip, take);
        }

        [HttpGet]
        [Route("{domainName}/articles/{articleId}")]
        public DataTransferObjects.Article GetArticle(string domainName, Guid articleId)
        {
            return new Managers.ArticleManager(domainName).Get(articleId);
        }

        [HttpDelete]
        [Route("{domainName}/articles/{articleId}")]
        [Authorize]
        public void DeleteArticle(string domainName, Guid articleId)
        {
            new Managers.ArticleManager(domainName).Delete(articleId, User.Identity.Name);
            StatusCode(HttpStatusCode.NoContent);
        }
    }
}
