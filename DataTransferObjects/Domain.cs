using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Sett.DataTransferObjects
{
    [DataContract]
    public class Domain
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Name;

        [DataMember]
        public string Uri;

        [DataMember]
        public string PageBaseUri;

        [DataMember]
        public string ArticleBaseUri;

        [DataMember]
        public IEnumerable<User> Users;
    }
}
