using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.Entities;
using Hobby.Services.Interfaces;
using Hobby.Services.Mappings;
using Hobby.Utilities.UserUtilities;

namespace Hobby.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;

        public UserService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserDTO CheckUser(string login, string password)
        {
            var passwordSHA = password.getSHA1();
            var entity = _uow.Users.FirstOrDefaultAsNoTracking(p => p.Login == login && p.Password == passwordSHA);

            if (entity != null)
            {
                return entity.Map();
            }
            else
            {
                return null;
            }
        }

        public List<string> PermissionActiveNameList(decimal idUser)
        {
            List<string> permissionActiveList = new List<string>();

            var entity = _uow.UserPermissions.AllAsNoTracking(p => p.IdUser == idUser).Select(p => p.IdPermission);
            foreach (var idPermission in entity)
            {
                var getActivePermission = _uow.Permissions.FirstOrDefaultAsNoTracking(p => p.Id == idPermission && p.Active == true);
                if (getActivePermission != null)
                {
                    permissionActiveList.Add(getActivePermission.Name);
                }
            }

            return permissionActiveList;
        }
    }
}
