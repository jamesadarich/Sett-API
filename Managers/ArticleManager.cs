using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;

namespace Sett.Managers
{
    public class ArticleManager
    {
        public IEnumerable<DataTransferObjects.Article> GetAll()
        {
            var t = new Models.Article();
            return new DataAccess.Repository().Articles.ToList().Select(a => a.ToDto());
        }

        public DataTransferObjects.Article Get(Guid articleId)
        {
            return new DataAccess.Repository().Articles
                                        .Where(a => a.Id == articleId)
                                        .ToList().Single().ToDto();
        }
    }
}
