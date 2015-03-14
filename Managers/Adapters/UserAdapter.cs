using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sett.Managers.Adapters
{
    public static class UserAdapter
    {
        public static DataTransferObjects.User ToDto(this Models.User user)
        {
            if (user == null) { return null; }

            var userDto = new DataTransferObjects.User();

            userDto.Id = user.Id;
            userDto.FirstName = user.FirstName;
            userDto.LastName = user.LastName;
            userDto.Username = user.Username;

            return userDto;
        }

        public static Models.User ToModel(this DataTransferObjects.User user, DataAccess.Repository repository)
        {
            if (user == null) { return null; }

            var userModel = new Models.User();
            userModel.Id = Guid.NewGuid();

            if (user.Id != new Guid())
            {
                userModel = repository.Users.Single(u => u.Id == user.Id);
            }
            userModel.FirstName = user.FirstName;
            userModel.LastName = user.LastName;
            userModel.Username = user.Username;

            return userModel;
        }
    }
}
