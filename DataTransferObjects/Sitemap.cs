using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Sett.DataTransferObjects
{
    [CollectionDataContract(Name = "urlset", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class Sitemap : List<SitemapItem>
    {
        public void AddItem(string location)
        {
            var item = new SitemapItem();
            item.Location = location;
            item.ChangeFrequency = SitemapItem.ChangeFrequencyPeriod.weekly;
            this.Add(item);
        }
    }
}
