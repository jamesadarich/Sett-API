using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Sett.DataTransferObjects
{
    [DataContract]
    public class Application
    {
        [DataMember]
        public Guid Id;

        [DataMember]
        public string Name;
    }
}
