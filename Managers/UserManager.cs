using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sett.Managers.Adapters;

namespace Sett.Managers
{
    public class UserManager
    {
        public DataTransferObjects.User GetByUsername(string username)
        {
            return new DataAccess.Repository().Users.Single(u => u.Username == username).ToDto();
        }
    }
}
