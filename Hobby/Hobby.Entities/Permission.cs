using Hobby.DTO;
using Hobby.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Entities
{
    public class Permission : PermissionDTO, IEntity
    {
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
