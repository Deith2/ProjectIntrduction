using Hobby.DTO;
using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Services.Mappings
{
    public static class UserPermissionMappings
    {
        public static UserPermissionDTO Map(this UserPermission source)
        {
            var target = new UserPermissionDTO();

            target.Id = source.Id;
            target.IdCategorie = source.IdCategorie;
            target.IdPermission = source.IdPermission;
            target.IdUser = source.IdUser;

            return target;
        }

        public static UserPermission Map(this UserPermissionDTO source)
        {
            var target = new UserPermission();

            target.Id = source.Id;
            target.IdCategorie = source.IdCategorie;
            target.IdPermission = source.IdPermission;
            target.IdUser = source.IdUser;

            return target;
        }
    }
}
