using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Sett.DataTransferObjects
{
    [DataContract]
    public class ArticleRevision
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Title;

        [DataMember]
        public string Content;

        [DataMember]
        public string Summary;

        [DataMember]
        public Guid ArticleId;

        [DataMember]
        public DateTime Timestamp;

        [DataMember]
        public User Author;

        [DataMember]
        public string FeaturedImageUrl;
    }
}
