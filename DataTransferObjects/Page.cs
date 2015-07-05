using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Sett.DataTransferObjects
{
    [DataContract]
    public class Page
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Title;

        [DataMember]
        public string Content;

        [DataMember]
        public string Uri;

        [DataMember]
        public IEnumerable<String> Keywords;

        [DataMember]
        public Domain Domain;
    }
}
