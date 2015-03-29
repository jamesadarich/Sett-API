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
        [Route("articles")]
        public IEnumerable<DataTransferObjects.Article> GetAllArticles( [FromUri] string where = null,
                                                                        [FromUri] string sort = null,
                                                                        [FromUri] int skip = 0,
                                                                        [FromUri] int take = 10)
        {
            return new Managers.ArticleManager().GetAll(where, sort, skip, take);
        }

        [HttpGet]
        [Route("articles/{articleId}")]
        public DataTransferObjects.Article GetArticle(Guid articleId)
        {
            return new Managers.ArticleManager().Get(articleId);
        }

        [HttpDelete]
        [Route("articles/{articleId}")]
        [Authorize]
        public void DeleteArticle(Guid articleId)
        {
            new Managers.ArticleManager().Delete(articleId, User.Identity.Name);
            StatusCode(HttpStatusCode.NoContent);
        }
    }
}
