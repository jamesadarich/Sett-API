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
        public IEnumerable<DataTransferObjects.Article> GetAllArticles()
        {
            return new Managers.ArticleManager().GetAll();
        }

        [HttpGet]
        [Route("articles/{articleId}")]
        public DataTransferObjects.Article GetArticle(Guid articleId)
        {
            return new Managers.ArticleManager().Get(articleId);
        }
    }
}
