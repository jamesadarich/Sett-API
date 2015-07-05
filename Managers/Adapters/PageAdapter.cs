using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett.Managers.Adapters
{
    public static class PageAdapter
    {
        public static DataTransferObjects.Page ToDto(this Models.Page page)
        {
            if (page == null) { return null; }

            var pageDto = new DataTransferObjects.Page();

            pageDto.Id = page.Id;
            pageDto.Uri = page.Uri;
            pageDto.Title = page.Title;
            pageDto.Content = page.Content;
            pageDto.Domain = page.Domain.ToDto();

            if (page.Keywords != null)
            {
                pageDto.Keywords = page.Keywords.Split(
                                                    new string[] { ", " },
                                                    StringSplitOptions.None);
            }

            return pageDto;
        }

        public static Models.Page ToModel(this DataTransferObjects.Page page)
        {
            if (page == null) { return null; }

            var pageModel = new Models.Page();

            pageModel.Id = page.Id;
            pageModel.Title = page.Title;
            pageModel.Content = page.Content;
            pageModel.DomainId = page.Domain.Id;

            if (page.Keywords != null)
            {
                pageModel.Keywords = String.Join(", ", page.Keywords);
            }

            return pageModel;
        }
    }
}
