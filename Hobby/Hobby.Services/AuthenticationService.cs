using Hobby.Common.Authentication;
using Hobby.Common.Enums;
using Hobby.Data.Interface;
using Hobby.DTO;
using Hobby.Entities;
using Hobby.Services.Interfaces;
using Hobby.Services.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Services
{
    public class AuthenticationService : IAuthenticateService
    {
        private readonly IUnitOfWork _uow;

        public AuthenticationService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public UserDTO CheckUser(string login, string password)
        {
            var passwordSHA = password.getSHA1();
            var entity = _uow.Users.FirstOrDefaultAsNoTracking(p => p.Email == login && p.Password == passwordSHA);

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
                var getActivePermission = _uow.Permissions.FirstOrDefaultAsNoTracking(p => p.Id == idPermission && p.Delete == false);
                if (getActivePermission != null)
                {
                    permissionActiveList.Add(getActivePermission.Name);
                }
            }

            return permissionActiveList;
        }

        public bool Register(UserDTO user)
        {
            var userExist = _uow.Users.SingleOrDefault(p => p.Email == user.Email);

            if (userExist == null)
            {
                var entity = user.Map();
                entity.Password = entity.Password.getSHA1();
                _uow.Users.Add(entity);
                _uow.Save();

                var permission = _uow.Permissions.Single(p => p.Value == (int)PermissionType.User && p.Delete == false);
                UserPermission userPermission = new UserPermission
                {
                    IdUser = entity.Id,
                    IdPermission = permission.Id,
                    LastModifyDate = DateTime.Now,
                };
                _uow.UserPermissions.Add(userPermission);
                _uow.Save();

                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
