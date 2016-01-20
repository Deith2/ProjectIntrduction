using Hobby.DTO;
using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Services.Mappings
{
    public static class PermissionMappings
    {
        public static PermissionDTO Map(this Permission source)
        {
            var target = new PermissionDTO();

            target.Description = source.Description;
            target.Id = source.Id;
            target.Name = source.Name;
            target.Active = source.Active;

            return target;
        }

        public static Permission Map(this PermissionDTO source)
        {
            var target = new Permission();

            target.Description = source.Description;
            target.Id = source.Id;
            target.Name = source.Name;
            target.Active = source.Active;

            return target;
        }
    }
}
