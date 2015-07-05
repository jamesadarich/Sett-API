using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett.Models
{
    public class Page : ModelWithId
    {
        public Page()
        {
            _id = Guid.NewGuid();
        }

        private Guid _id;
        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private string _uri;
        public string Uri
        {
            get
            {
                return _uri;
            }
            set
            {
                _uri = value;
            }
        }

        private string _title;
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
            }
        }

        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        private string _keywords;
        public string Keywords
        {
            get
            {
                return _keywords;
            }
            set
            {
                _keywords = value;
            }
        }

        private Guid _domainId;
        public Guid DomainId
        {
            get { return _domainId; }
            set { _domainId = value; }
        }

        public virtual Domain Domain
        {
            get;
            set;
        }
    }
}
