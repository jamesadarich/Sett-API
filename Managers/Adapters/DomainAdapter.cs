using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett.Managers.Adapters
{
    public static class DomainAdapter
    {
        public static DataTransferObjects.Domain ToDto(this Models.Domain domain)
        {
            if (domain == null) { return null; }

            var domainDto = new DataTransferObjects.Domain();
            domainDto.Id = domain.Id;
            domainDto.Name = domain.Name;
            domainDto.Uri = domain.Uri;
            domainDto.PageBaseUri = domain.PageBaseUri;
            domainDto.ArticleBaseUri = domain.ArticleBaseUri;

            if (domain.Users != null)
            {
                domainDto.Users = domain.Users.Select(user => user.ToDto());
            }

            return domainDto;
        }
        public static Models.Domain ToModel(this DataTransferObjects.Domain domain)
        {
            if (domain == null) { return null; }

            var domainModel = new Models.Domain();
            domainModel.Id = domain.Id;
            domainModel.Name = domain.Name;
            domainModel.Uri = domain.Uri;
            domainModel.PageBaseUri = domain.PageBaseUri;
            domainModel.ArticleBaseUri = domain.ArticleBaseUri;

            return domainModel;
        }
    }
}
