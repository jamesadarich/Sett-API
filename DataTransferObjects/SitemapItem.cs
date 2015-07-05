using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Sett.DataTransferObjects
{
    [DataContract(Name = "url", Namespace = "http://www.sitemaps.org/schemas/sitemap/0.9")]
    public class SitemapItem
    {
        [DataMember(Name = "loc")]
        public string Location;

        [DataMember(Name = "lastmod", EmitDefaultValue = false)]
        public Nullable<DateTime> LastModified;

        [DataMember(Name = "changefreq", EmitDefaultValue = false)]
        public Nullable<ChangeFrequencyPeriod> ChangeFrequency;

        [DataMember(Name = "priority", EmitDefaultValue = false)]
        public Nullable<double> Priority;

        public enum ChangeFrequencyPeriod
        {
            always,
            hourly,
            daily,
            weekly,
            monthly,
            yearly,
            never
        }
    }
}
