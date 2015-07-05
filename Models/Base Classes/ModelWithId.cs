using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett.Models
{
    public abstract class ModelWithId : Model
    {
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
    }
}
