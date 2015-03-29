using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;
using Sett.DataAccess.Extensions;

namespace Sett.Managers
{
    public class ArticleManager
    {
        public IEnumerable<DataTransferObjects.Article> GetAll(string where, string sort, int skip, int take)
        {
            var t = new Models.Article();
            return new DataAccess.Repository().Articles
                                            .Filter(where)
                                            .Sort(sort)
                                            .Skip(skip)
                                            .Take(take)
                                            .ToList()
                                            .Select(a => a.ToDto());
        }

        public DataTransferObjects.Article Get(Guid articleId)
        {
            return new DataAccess.Repository().Articles
                                        .Where(a => a.Id == articleId)
                                        .ToList().Single().ToDto();
        }

        public void Delete(Guid articleId, string username)
        {
            var repository =  new DataAccess.Repository();
            var user = repository.Users.Single(u => u.Username == username);
            var article = repository.Articles.Single(a => a.Id == articleId);
            repository.Articles.Remove(article);
            repository.SaveChanges();
        }
    }
}
